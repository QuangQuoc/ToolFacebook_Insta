using ControlLdPlayer.Services;
using ControlLdPlayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLdPlayer.ViewModels
{
    public class LdPlayerViewModel
    {
        private LdPlayer form;
        public string Name { get; set; }

        public string Resolution { get; set; }

        public string Cpu { get; set; }

        public string Memory { get; set; }

        public string Imei { get; set; }

        public string PackageName { get; set; }

        public LdPlayerViewModel(LdPlayer _form)
        {
            form = _form;
            // Default Parameters Property Setting
            Resolution = "600,360,160";
            Memory = "1024";
            Cpu = "1";
            Imei = "auto";
        }

        public void ReadName()
        {
            Name = form.ReadtbxName();
        }

        public void ReadPropertySetting()
        {
            string resolution = form.tbxResolution.Text.ToString();
            string memory = form.tbxMemory.Text.ToString();
            string cpu = form.tbxCpu.Text.ToString();
            string imei = form.tbxImei.Text.ToString();
            if (resolution != "")
            {
                Resolution = resolution;
            }
            if (memory != "")
            {
                Memory = memory;
            }
            if (cpu != "")
            {
                Cpu = cpu;
            }
            if (imei != "")
            {
                Imei = imei;
            }
        }

        public void ReadPackgeName()
        {
            PackageName = form.tbxFileApk.Text;
        }
    }
}
