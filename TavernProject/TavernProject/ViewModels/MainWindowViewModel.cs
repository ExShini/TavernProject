using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TavernProject.Models;

namespace TavernProject.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Visitor> VisitorColl { get; private set; }

        [ObservableProperty]
        public Visitor _selectedVisitor;

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


        partial void OnSelectedVisitorChanged(Visitor value)
        {
            // Логика обновления окна информации должна быть тут!
        }


    }
}
