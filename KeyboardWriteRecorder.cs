using System;
using System.Text;
using System.Windows.Forms;

namespace Final_app
{
    internal class KeyboardWriteRecorder
    {
        public bool isInUse {  get; private set; } = false;
        private StringBuilder currentPrompt;
        public Action<string> onRecordingStopped;
        public Action onRecordingStarted;

        public KeyboardWriteRecorder()
        {
             currentPrompt = new StringBuilder();
        }

        public void StartRecording()
        {
            if (!isInUse)
            {
                onRecordingStarted?.Invoke();
                isInUse = true;
            }
        }

        public void StopRecording()
        {
            isInUse = false;
            onRecordingStopped?.Invoke(currentPrompt.ToString());
            currentPrompt.Clear();
        }
        
        public void RecordKeyInput(KeyEventArgs key)
        {
            if (!isInUse) return;

            if (IsLetterOrNumber(key))
            {
                Console.WriteLine(key.KeyCode);
                currentPrompt.Append(key.KeyCode.ToString().ToLower());
            }
            else
            {
                if (key.KeyCode == Keys.Back)
                {
                    sb.Length--;
                }
            }
        }

        private static bool IsLetterOrNumber(KeyEventArgs e)
        {
            char keyChar = (char)e.KeyValue;

            return char.IsLetterOrDigit(keyChar);
        }
    }
}