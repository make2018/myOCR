﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.ServiceProcess;
using DX.Service;
using DX.Utilities;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using DX.Log;
using generalPLC;


namespace myOCR
{
    public partial class MainForm : Form
    {
        private DXLog logger { get; set; }

        public delegate void SetTextCallBack(string text);                  //在子线程内 修改 主线程控件的值
        public delegate void SetButtonCallBack(int index, int status);      //在子线程内 修改 主线程控件的状态
        OCRService service = new OCRService();
        private string m_location;
        private string m_serviceName;
        private string m_description;
        private bool m_showing = false;
        private Bitmap m_bkBitmap;
        //  WinServiceUtil serviceUtil = new WinServiceUtil();

        PLC plc = new PLC();

          

     
        


        public MainForm()
        {
            DXLog.InitLog();
            this.logger = DXLog.GetLogger(typeof(MainForm));
            InitializeComponent();
        }

        private void btn_show_image_Click(object sender, EventArgs e)
        {
            if (!m_showing)
            {
                service.InitOCRService(true, Constants.CAMERAPATH);

                timer1.Enabled = true;
                m_showing = true;
                btn_show_image.Text = "停止播放";
            }
            else
            {
                m_showing = false;
                timer1.Enabled = false;
                service.ReleaseOCRService();

                pictureBox1.Image = m_bkBitmap;
                btn_show_image.Text = "显示画面";
            }
        }

   

    

        private void btn_ReadValue_Click(object sender, EventArgs e)
        {
           // textBox1.Text = plc.getChars(Constants.PLCIP, Convert.ToInt32(Constants.Rack), Convert.ToInt32(Constants.Slot), 2, 0, 4);
            textBox1.Text = plc.getChars(2, 0, 4);
        }

        private void btn_WriteValue_Click(object sender, EventArgs e)
        {
            // plc.setChars(Constants.PLCIP, Convert.ToInt32(Constants.Rack), Convert.ToInt32(Constants.Slot), 2, 0, 4, textBox2.Text);
            plc.setChars(2, 0, 4, textBox2.Text);
        }
    }
}