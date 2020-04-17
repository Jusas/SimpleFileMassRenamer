using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FileMassRenamer.Utils;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;

namespace FileMassRenamer
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.Directory)]
    [COMServerAssociation(AssociationType.AllFiles)]
    public class ShellExtension : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return SelectedItemPaths.Any();
        }

        protected override ContextMenuStrip CreateMenu()
        {
            var menu = new ContextMenuStrip();
            var item = new ToolStripMenuItem
            {
                Text = "Mass rename..."
            };

            item.Click += (sender, args) => MenuAction();
            menu.Items.Add(item);
            return menu;
        }

        private void MenuAction()
        {

            var form = new FRMMain();
            var selectedItemPaths = SelectedItemPaths.ToList();
            selectedItemPaths = PathTools.ExpandToFileList(selectedItemPaths);
            form.SourceFilenames = selectedItemPaths;
            form.InitializeFormData();
            form.Show();

        }
    }
}
