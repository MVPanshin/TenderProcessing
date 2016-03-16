﻿using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using SpeCalc.Helpers;
using SpeCalcDataAccessLayer.Objects;
using SpeCalcDataAccessLayer.ProjectModels;

namespace SpeCalc.Objects
{
    //[WhitespaceFilter]
    public class BaseController:Controller
    {
        private static NetworkCredential nc = GetAdUserCredentials();
        public static NetworkCredential GetAdUserCredentials()
        {
            string accUserName = @"UN1T\adUnit_prog";
            string accUserPass = "1qazXSW@";

            string domain = "UN1T";//accUserName.Substring(0, accUserName.IndexOf("\\"));
            string name = "adUnit_prog";//accUserName.Substring(accUserName.IndexOf("\\") + 1);

            NetworkCredential nc = new NetworkCredential(name, accUserPass, domain);

            return nc;
        }
        protected AdUser CurUser;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DisplayCurUser();
            base.OnActionExecuting(filterContext);
        }

        [NonAction]
        public AdUser GetCurUser()
        {
            if (Session["CurUser"] != null)
            {
                return (AdUser)Session["CurUser"];
            }

            AdUser user = new AdUser();
            user.User = base.User;
            try
            {

                //////List<GroupPrincipal> result = new List<GroupPrincipal>();

                //////// establish domain context
                //////PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);

                //////// find your user
                //////UserPrincipal usr = UserPrincipal.FindByIdentity(yourDomain, userName);

                //////// if found - grab its groups
                //////if (user != null)
                //////{
                //////    PrincipalSearchResult<Principal> groups = usr.GetAuthorizationGroups();

                //////    // iterate over all groups
                //////    foreach (Principal p in groups)
                //////    {
                //////        // make sure to add only group principals
                //////        if (p is GroupPrincipal)
                //////        {
                //////            result.Add((GroupPrincipal)p);
                //////        }
                //////    }
                //////}

                //////return user;

                string fakeSid = null;
                string fakeLosgin = null;
                //fakeSid = "S-1-5-21-1970802976-3466419101-4042325969-3837";
                //fakeLosgin = "olga.skidan";

                // заглушка для входа извне
                #region trickForLogOn
                user.Email = "maxim.panshin@unitgroup.ru"; ;
                user.FullName = "Maxim Panshin";
                user.Sid = "S-1-5-21-1970802976-3466419101-4042325969-7670";
                    //Кузнецов "S-1-5-21-1970802976-3466419101-4042325969-3343";
                // Тигин "S-1-5-21-1970802976-3466419101-4042325969-7670";

                //"S-1-5-21-1970802976-3466419101-4042325969-2365";

                //user.AdGroups = new List<AdGroup> { AdGroup.SuperAdmin };
                user.AdGroups = new List<AdGroup> { AdGroup.SpeCalcManager };
                Session["CurUser"] = user;

                return user;
                #endregion trickForLogOn

                using (WindowsImpersonationContextFacade impersonationContext
                    = new WindowsImpersonationContextFacade(
                        nc))
                {
                    var wi = (WindowsIdentity)base.User.Identity;
                    if (wi.User != null)
                    {
                        var domain = new PrincipalContext(ContextType.Domain);
                        string sid = fakeSid ?? wi.User.Value;
                        user.Sid = sid;
                        var login = fakeLosgin ?? wi.Name.Remove(0, wi.Name.IndexOf("\\", StringComparison.CurrentCulture) + 1);
                        user.Login = login;
                        var userPrincipal = UserPrincipal.FindByIdentity(domain, login);
                        if (userPrincipal != null)
                        {
                            var mail = "maxim.panshin@unitgroup.ru";    //userPrincipal.EmailAddress;
                            var name = "Maxim Panshin";                 //userPrincipal.DisplayName;
                            user.Email = mail;
                            user.FullName = name;
                            //user.DepartmentName = userPrincipal.
                            //user.AdGroups = new List<AdGroup>();
                            //var wp = new WindowsPrincipal(wi);
                            //foreach (var role in AdUserGroup.GetList())
                            //{
                            //    var grpSid = new SecurityIdentifier(role.Sid);
                            //    if (wp.IsInRole(grpSid))
                            //    {
                            //        user.AdGroups.Add(role.Group);
                            //    }
                            //}
                            AdHelper.SetUserAdGroups(wi, ref user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            //Доступы в проектах
            //user.ProjectAccess = GetProjectAccess(user);

            Session["CurUser"] = user;

            return user;
        }

        protected AdUser DisplayCurUser()
        {
            CurUser = GetCurUser();
            if (CurUser == new AdUser()) RedirectToAction("AccessDenied", "Error");
            ViewBag.CurUser = CurUser;
            return CurUser;
        }

        //private ProjectAccessModel GetProjectAccess(AdUser user)
        //{

        //    var acc = new ProjectAccessModel(user);
        //    acc.CanViewAllProjects = user.HasAccess(AdGroup.SpeCalcProjectControler);
        //    acc.CanViewHistory = false;
        //    acc.CanChangeTeam = false;
        //    acc.CanViewTeam = false;
        //    acc.CanChangeInfo = false;
        //    acc.CanChangeCondition = false;
        //    acc.CanViewCondition = false;
        //    acc.CanAddFiles = false;
        //    acc.CanViewHistory = false;
        //    acc.CanViewHistory = false;
        //    acc.CanViewHistory = false;
        //    acc.CanViewHistory = false;
        //    acc.CanViewHistory = false;
        //    acc.CanViewHistory = false;
        //    acc.CanViewHistory = false;
        //    acc.CanViewHistory = false;
        //    acc.CanViewHistory = false;
        //    acc.CanViewHistory = false;
        //}
    }
}