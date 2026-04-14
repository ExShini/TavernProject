using System.Collections.ObjectModel;
using TavernProject.Models;

namespace TavernProject.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Visitor> VisitorColl { get; private set; }


        private readonly TavernSimulator simulator;

        public MainWindowViewModel()
        {
            simulator = new TavernSimulator();
            VisitorColl = new ObservableCollection<Visitor>();

            SyncTavernVisitors();
        }

        private void SyncTavernVisitors()
        {
            VisitorColl.Clear();
            if (simulator.Visitors != null)
            {
                for (int i = 0; i < simulator.Visitors.Count; i++)
                {
                    var visitorToAdd = simulator.Visitors[i];
                    VisitorColl.Add(visitorToAdd);
                }
            }
        }
    }
}
