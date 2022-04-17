using PropertyTools.DataAnnotations;
using System;

namespace VentWPF.ViewModel
{
    internal interface IDoubleElement
    {
        [Browsable(false)]
        Element TopElement { get; }
    }

    internal interface IDoubleLinkedElement
    {

    }
}