using STOBusinessLogic.BusinessLogics;
using STOBusinessLogic.Interfaces;
using STODataBaseImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace STOView
{
    static class Program
    {
        public static bool isLogged = false;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var formEnter = new FormEnter();
            formEnter.ShowDialog();
            if (isLogged)
            {
                Application.Run(container.Resolve<FormMain>());
            }

        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IPart, PartLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWork, WorkLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
