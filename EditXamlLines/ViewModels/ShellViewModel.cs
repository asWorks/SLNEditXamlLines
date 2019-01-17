using EditXamlLines.EventMessages;
using EditXamlLines.Interfaces;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EditXamlLines.Models;

namespace EditXamlLines.ViewModels
{
    [Export(typeof(IShellViewModel))]
    public class ShellViewModel : Conductor<object>, IShellViewModel, IHandle<EventMessage>
    {

     

        private readonly IEventAggregator _events;
        private readonly IMainDisplayViewModel MainDisplayVModel;
        //private readonly IWeekDisplayViewModel weekDisplayViewModel;
        //private readonly ITestPeopleViewModel testPeopleViewModel;
        //public IWeekDisplayViewModel weekDisplayViewModel { get; set; }

       

        



        #region Constructors
        public ShellViewModel()
        {



        }

        [ImportingConstructor]
        public ShellViewModel(IMainDisplayViewModel mainDisplayVM,
                     IEventAggregator events)
        {
            _events = events;
            

            events.Subscribe(this);

            MainDisplayVModel = mainDisplayVM;

        }
        #endregion



        public void MainDisplay()
        {
            ActivateItem(MainDisplayVModel);
        }


        //public void Test()
        //{
        //    ActivateItem(new TestViewModel());
        //}

        //public void AerzteListe()
        //{
        //    ActivateItem(AerzteListeVModel);

        //}

        //public void TestPeople()
        //{
        //    ActivateItem(testPeopleViewModel);
        //}

        public void Handle(EventMessage message)
        {
            throw new NotImplementedException();
        }
    }
}