using System.Windows;
using NAudio.Midi;

namespace PianoTrainer
{
    public partial class MainWindow : Window
    {
        private MidiIn? _midiIn;

        public MainWindow()
        {
            InitializeComponent();
            InitializeMidi();
        }

        private void InitializeMidi()
        {
            if (MidiIn.NumberOfDevices > 0)
            {
                _midiIn = new MidiIn(0);
                _midiIn.MessageReceived += MidiInOnMessageReceived;
                _midiIn.Start();
            }
            else
            {
                NoteList.Items.Add("No MIDI input devices found");
            }
        }

        private void MidiInOnMessageReceived(object? sender, MidiInMessageEventArgs e)
        {
            if (e.MidiEvent is NoteEvent note)
            {
                Dispatcher.Invoke(() =>
                {
                    NoteList.Items.Add($"Note {note.NoteName} Velocity {note.Velocity}");
                    if (NoteList.Items.Count > 50)
                        NoteList.Items.RemoveAt(0);
                });
            }
        }

        protected override void OnClosed(System.EventArgs e)
        {
            _midiIn?.Dispose();
            base.OnClosed(e);
        }
    }
}
