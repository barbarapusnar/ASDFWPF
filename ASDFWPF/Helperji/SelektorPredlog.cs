using System.Windows;
using System.Windows.Controls;


namespace ASDFWPF
{
    internal class SelektorPredlog : DataTemplateSelector
    {
        public DataTemplate MojaPredloga { get; set; }
        public DataTemplate ZeReseno { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (item is Vaje)
            {
                var taskitem = item as Vaje;
                var up = PrivzetiViewModel.Uporabnik;
                var x = PrivzetiViewModel.GetItemRUp(taskitem.Id, up);
                if (x != null)
                {
                    taskitem.napake = x.napake;
                    taskitem.zadnjicReseno = x.zadnjicReseno;
                    taskitem.porabljencas = x.udarci;
                    return ZeReseno;
                }
                return MojaPredloga;
            }
            return MojaPredloga;
        }
        
    }
}