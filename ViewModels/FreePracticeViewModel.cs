using RaceDirector.Models;
using RaceDirector.ServiceContracts;

namespace RaceDirector.ViewModels
{
    public class FreePracticeViewModel
    {
        private FreePractice _freePractice;
        private IArduinoService _arduinoService;

        public FreePractice FreePractice => _freePractice;

        public FreePracticeViewModel()
        {
            _freePractice = new FreePractice();
            _arduinoService = Container.Resolve<IArduinoService>();
        }
    }
}