using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxyText_Editor
{
    public static class Temporary
    {
        public static ToolStripMenuItem TSMI_SetTag(ToolStripMenuItem tsmi ,object settag) 
        {
            tsmi.Tag = settag;
            return tsmi;
        }

        
        
    }
    
    
    
}
