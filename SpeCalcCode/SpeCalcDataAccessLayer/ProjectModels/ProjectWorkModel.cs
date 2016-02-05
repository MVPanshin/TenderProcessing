﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeCalcDataAccessLayer.Objects;

namespace SpeCalcDataAccessLayer.ProjectModels
{
    public class ProjectWorkModel
    {
        public ProjectWorks Work { get; set; }
        public bool HasCalculations { get; private set; }
        public List<ProjectWorkCalculations> _calculations; 
        public List<ProjectWorkCalculations> Calculations
        {
            get { return _calculations; }
            set
            {
                _calculations = value;
                HasCalculations = Calculations.Any();
            }
        }

        public ProjectWorkModel()
        {
            Work = new ProjectWorks();
            Calculations=new List<ProjectWorkCalculations>();
        }

        public static int Create(ProjectWorks work, AdUser user)
        {
            using (var db = new SpeCalcEntities())
            {
                work.Enabled = true;
                work.CreatorSid = user.Sid;
                work.CreatorName = user.DisplayName;
                work.CreateDate = DateTime.Now;
                db.ProjectWorks.Add(work);
                SetState(work, user, db);
                db.SaveChanges();
                return work.Id;
            }
        }

        public static void Save(ProjectWorks work, AdUser user)
        {
            using (var db = new SpeCalcEntities())
            {
                var oldwork =db.ProjectWorks.Single(x=>x.Id==work.Id);
                oldwork.Name = work.Name;
                oldwork.Quantity = work.Quantity;
                oldwork.QuantityUnitId = work.QuantityUnitId;
                oldwork.CalculatorSid = work.CalculatorSid;
                oldwork.CalculatorName = work.CalculatorName;
                db.SaveChanges();
            }
        }

        public static void Delete(int id, AdUser user)
        {
            using (var db = new SpeCalcEntities())
            {
                var work = db.ProjectWorks.Single(x => x.Id == id);
                work.Enabled = false;
                work.DeleteDate = DateTime.Now;
                work.DeleterSid = user.Sid;
                work.DeleterName = user.DisplayName;
                db.SaveChanges();
            }
        }

        public static void SetState(ProjectWorks work, AdUser user, SpeCalcEntities context = null)
        {
            bool hasContext = context != null;
            var db = context ?? new SpeCalcEntities();

            work.StateChangeDate = DateTime.Now;
            work.StateChangerSid = user.Sid;
            work.StateChangerName = user.DisplayName;
            work.StateId = ProjectStateModel.GetState("NEW").Id;
            db.ProjectWorks.Add(work);

            if (!hasContext)
            {
                db.SaveChanges();
                db.Dispose();
            }

        }

        public static ProjectWorks Get(int id)
        {
            using (var db = new SpeCalcEntities())
            {
                return db.ProjectWorks.SingleOrDefault(x => x.Id == id);
            }
        }

        public static ProjectWorkModel GetWithCalc(int id)
        {
            //using (var db = new SpeCalcEntities())
            //{
                var db = new SpeCalcEntities();
                var work = db.ProjectWorks.Include(x=>x.ProjectWorkQuantityUnits).SingleOrDefault(x => x.Id == id);
                var calculations = db.ProjectWorkCalculations.Where(x => x.Enabled && x.WorkId==id).Include(x=>x.ProjectCurrencies).Include(x=>x.ProjectWorkExecutinsTimes).ToList();
                var p = new ProjectWorkModel();
                p.Work = work;
                p.Calculations = calculations.ToList();
                return p;
            //}
        }

        public static IEnumerable<ProjectWorkModel> GetListWithCalc(int projectId)
        {
            var db = new SpeCalcEntities();
            //using (var db = new SpeCalcEntities())
            //{
                var list = new List<ProjectWorkModel>();
                var works = db.ProjectWorks.Where(x => x.Enabled && x.ProjectId == projectId).ToList();
                var calculations =  db.ProjectWorkCalculations.Where(x => x.Enabled && x.ProjectWorks.ProjectId == projectId).Include(x => x.ProjectCurrencies).Include(x => x.ProjectWorkExecutinsTimes).ToList();
                int i = 0;
                foreach (ProjectWorks work in works)
                {
                    i++;
                    work.RowNum = i.ToString();
                    var p = new ProjectWorkModel();
                    p.Work = work;
                    p.Calculations = calculations.Where(x=>x.WorkId==work.Id).ToList();
                    list.Add(p);
                }
                return list;
            //}
            
        } 
    }
}