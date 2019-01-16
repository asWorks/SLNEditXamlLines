using Caliburn.Micro;
using System.ComponentModel.Composition;
using $safeprojectname$.EventMessages

namespace EditXamlLines.ViewModels
{
    [Export(typeof(ICaliburnMicroViewModelTemplate3))]
    public class CaliburnMicroViewModelTemplate3 : Screen, ICaliburnMicroViewModelTemplate3, IHandle<Events.EventMessage>
    {
        #region "Private Fields"
        private readonly IEventAggregator _events;
        private IExampleViewModel exampleVModel;

        #endregion


        #region "Constructors"
        [ImportingConstructor]
        public CaliburnMicroViewModelTemplate3(IExampleViewModel exampleVM,
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

public interface ICaliburnMicroViewModel
    {
    }