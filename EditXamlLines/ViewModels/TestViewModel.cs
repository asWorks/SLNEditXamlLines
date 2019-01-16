using Caliburn.Micro;
using System.ComponentModel.Composition;
using $projectname$.EventMessages;

namespace EditXamlLines.ViewModels
{
    [Export(typeof(ITestViewModel))]
    public class TestViewModel : Screen, ITestViewModel, IHandle<EventMessages.EventMessage>
    {
        #region "Private Fields"
        private readonly IEventAggregator _events;
        private IExampleViewModel exampleVModel;

        #endregion


        #region "Constructors"
        [ImportingConstructor]
        public TestViewModel(IExampleViewModel exampleVM,
                       IEventAggregator events)
        {
            _events = events;
            events.Subscribe(this);

            exampleVModel = exampleVM;

        }


        #endregion



        #region "Properties"
        //##################

        #endregion

        #region "Methods"
        //##################

        #endregion

        #region "CallsFromView"
        //##################

        #endregion

        #region "Eventhandlers"
        //##################

        public void Handle(EventMessages.EventMessage message)
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }

}

public interface ITestViewModel
{
}