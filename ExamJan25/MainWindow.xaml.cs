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

            //creating event objects
            Event event1 = new Event("Oasis Croke Park", new DateTime(2025, 06, 20), EventType.Music);
            Event event2 = new Event("Electric Picnic", new DateTime(2025, 08, 20), EventType.Music);

            //creating ticket objects
            Ticket ticket1 = new Ticket("Early Bird", 100.00m, 100);
            Ticket ticket2 = new Ticket("Platinum", 150.00m, 100);
            //creating VIP ticket objects
            VIPTicket vipTicket1 = new VIPTicket("Ticket and Hotel Package", 150.00m, 100, "4* hotel", 100.00m);
            VIPTicket vipTicket2 = new VIPTicket("Weekend Ticket", 200.00m, 100, "with camping", 100.00m);
        }

    }


    //creating base class Ticket
    public class Ticket
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableTickets { get; set; }
        public Ticket(string name, decimal price, int availableTickets)
        {
            Name = name;
            Price = price;
            AvailableTickets = availableTickets;
        }
    }

    //creating derived class VIPTicket
    public class VIPTicket : Ticket
    {
        public string AdditionalExtras { get; set; }
        public decimal AdditionalCost { get; set; }
        public VIPTicket(string name, decimal price, int availableTickets, string additionalExtras, decimal additionalCost)
            : base(name, price, availableTickets)
        {
            AdditionalExtras = additionalExtras;
            AdditionalCost = additionalCost;
        }
    }

    public class Event : IComparable<Event>
    {
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public List<Ticket> Tickets { get; set; }
        public EventType TypeOfEvent { get; set; }
        
        public Event(string name, DateTime eventDate, EventType typeOfEvent)
        {
            Name = name;
            EventDate = eventDate;
            TypeOfEvent = typeOfEvent;
            Tickets = new List<Ticket>();
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
