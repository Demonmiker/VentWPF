﻿using PropertyTools.DataAnnotations;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    public class ProjectInfoVM : BaseViewModel
    {
        /// <summary>
        /// Не пользоватся
        /// </summary>
        public ProjectInfoVM()
        {

        }


        public static ProjectInfoVM Instance { get; private set; } = new ProjectInfoVM();

        [Description("Описание")]
        public int VFlow { get; set; } = 6000;

        public int Resist { get; set; }
        public int Trend { get; set; }
        public int Humid { get; set; } = 85;
        public float PD { get; set; } = 500;
        public float PDd { get; set; } = 0;
        public int Width { get; set; } = 500;
        public int Height { get; set; } = 500;
        public int temp { get; set; } = -30;
        public float PressOut { get; set; } = 100;

        public Rows Rows { get; set; } = Rows.Row2;
    }
}