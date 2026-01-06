using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamJan25
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public enum EventType //enum for event class
    {
        Music, 
        Comedy, 
        Theatre
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //creating base class Ticket
        public class Ticket
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int AvailableTickets { get; set; }
            public void SampleMethod()
            {
                Console.WriteLine("SampleMethod called.");
            }
        }

        //creating derived class VIPTicket
        public class VIPTicket : Ticket
        {
            public string AdditionalExtras { get; set; }
            public decimal AdditionalCost { get; set; }
            public void VIPMethod()
            {
                Console.WriteLine("VIPMethod called.");
            }
        }

        public class Event: IComparable<Event>
        {
            public string Name { get; set; }
            public DateTime EventDate { get; set; }
            public List<Ticket> Tickets { get; set; }
            public EventType TypeOfEvent { get; set; }
            public void EventMethod()
            {
                Console.WriteLine("EventMethod called.");
            }
            // Implement IComparable
            public int CompareTo(Event other)
            {
                if (other == null)
                {
                    return 1;
                }

                return this.EventDate.CompareTo(other.EventDate);
            }
        }
    }
}
