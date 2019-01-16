namespace EditXamlLines
{
    using System;
    using System.Collections.Generic;
    using EditXamlLines.Interfaces;
    using EditXamlLines.ViewModels;
    using EditXamlLines;
    using Caliburn.Micro;
  

    public class Bootstrapper : BootstrapperBase {
        SimpleContainer container;

        public Bootstrapper() {
            Initialize();
        }

        protected override void Configure() {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.PerRequest<IShellViewModel, ShellViewModel>();
            container.PerRequest<IMainDisplayViewModel, MainDisplayViewModel>();

            //container.PerRequest<IAerzteListeViewModel, AerzteListeViewModel>();
            //container.PerRequest<IWeekDisplayViewModel, WeekDisplayViewModel>();
            //container.PerRequest<IWeekDayViewModel, AppointmentsAndRessourses.ViewModels.WeekDayViewModel>();
            //container.PerRequest<ITestPeopleViewModel, TestPeopleViewModel>();
        }

        protected override object GetInstance(Type service, string key) {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service) {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance) {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e) {
            DisplayRootViewFor<IShellViewModel>();
        }
    }
}