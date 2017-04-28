using LNTrello.Models.Repositories;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc3;

namespace LNTrello
{
    public static class BootStrapper
    {
        public static void Initialize()
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver(BuildUnityContainer()));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IDashboardRepository, DashboardServiceRepository>();
            container.RegisterType<ICardRepository, CardServiceRepository>();
            container.RegisterType<ICommentRepository, CommentServiceRepository>();
            container.RegisterInstance<IServiceManager>(TrelloServiceManager.Default);

            return container;
        }
    }
}