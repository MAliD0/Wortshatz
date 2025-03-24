using System.Collections.Generic;
using System.Windows.Forms;

namespace Final_app
{
    public class WindowsManager
    {
        public List<GroupBox> windows;
        public GroupBox lastOpenedTab { get; private set; }
        public GroupBox currentlyOpenedTab { get; private set; }

        public WindowsManager(List<GroupBox> windows)
        {
            this.windows = new List<GroupBox>(windows);
        }

        public void HideAllWindows()
        {
            foreach (GroupBox grp in windows)
            {
                grp.Hide();
                grp.SendToBack();
            }
        }

        public void ShowWindow(GroupBox box)
        {
            if(box == null || currentlyOpenedTab == box) { return; }
            HideAllWindows();
            if(currentlyOpenedTab != lastOpenedTab)
            {
                lastOpenedTab = currentlyOpenedTab;
            }
            currentlyOpenedTab = box;
            
            box.Show();
            box.BringToFront();
        }
        public void CloseWindow(GroupBox box)
        {
            if(currentlyOpenedTab == box) currentlyOpenedTab = null;
            box.Hide();
        }
    }
}
