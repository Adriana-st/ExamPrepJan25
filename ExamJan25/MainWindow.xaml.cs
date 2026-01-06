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
        List<Event> events = new List<Event>(); //list to hold event objects

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            //creating ticket objects for event1
            Ticket ticket1 = new Ticket("Early Bird", 100.00m, 100);
            Ticket ticket2 = new Ticket("Platinum", 150.00m, 100);
            VIPTicket vipTicket1 = new VIPTicket("Ticket and Hotel Package", 150.00m, 100, "4* hotel", 100.00m);
            
            //adding tickets to event1 ticket list
            List<Ticket> e1Tickets = new List<Ticket>() { ticket1, ticket2, vipTicket1}; //list to hold ticket objects for event1

            //creating event objects
            Event event1 = new Event("Oasis Croke Park", new DateTime(2025, 06, 20), EventType.Music, e1Tickets);
            events.Add(event1);

            Ticket t1 = new Ticket("Friday", 100m, 100);
            Ticket t2 = new Ticket("Saturday", 100m, 100);
            Ticket t3 = new Ticket("Sunday", 100m, 100);
            Ticket t4 = new Ticket("Weekend", 200m, 100);
            VIPTicket vipT5 = new VIPTicket("Weekend Ticket", 200.00m, 100, "with camping", 100.00m);

            List<Ticket> e2Tickets = new List<Ticket>() { t1, t2, t3, t4, vipT5 }; //list to hold ticket objects for event1

            Event event2 = new Event("Electric Picnic", new DateTime(2025, 08, 20), EventType.Music, e2Tickets);
            events.Add(event2);
            lbxEvents.ItemsSource = events; //binding events list to listbox
            //lbxTickets.ItemsSource = tickets; //binding tickets list to listbox
        }

        private void lbxEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //determine what event is selected
            Event selectedEvent = lbxEvents.SelectedItem as Event;

            // check it is not null
            if (selectedEvent != null)
            {
                //display tickets for that event in the tickets listbox
                lbxTickets.ItemsSource = null; //clear previous items
                lbxTickets.ItemsSource = selectedEvent.Tickets;
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //read amount required
            int numberRequired = int.Parse(tbxNumberOfTickets.Text);
            //check availability
            Ticket selectedTicket = lbxTickets.SelectedItem as Ticket;

            //ensure not null
            if (selectedTicket != null)
            {
                int available = selectedTicket.AvailableTickets;

                if (available >= numberRequired)
                {
                    //reduce number of tickets available
                    selectedTicket.AvailableTickets -= numberRequired;
                    MessageBox.Show($"Booking confirmed for {numberRequired} tickets of {selectedTicket.Name}");

                    //refresh tickets listbox
                    lbxTickets.ItemsSource = null; //clear previous items
                    Event selectedEvent = lbxEvents.SelectedItem as Event;

                    if (selectedEvent != null)
                    {
                         lbxTickets.ItemsSource = selectedEvent.Tickets;
                    }
                }
                else
                {
                    MessageBox.Show($"Only {available} tickets available for {selectedTicket.Name}. P;ease reduce the number of tickets required.");
                }
            }

            
        }
    }


    //creating base class Ticket
    public class Ticket
    {
        //properties
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableTickets { get; set; }

        //constructors
        public Ticket()
        {
            
        }
        public Ticket(string name, decimal price, int availableTickets)
        {
            Name = name;
            Price = price;
            AvailableTickets = availableTickets;
        }

        //methods
        public override string ToString()
        {
            return $"{Name} - {Price:C} [AVAILABLE - {AvailableTickets}]";
        }
    }

    //creating derived class VIPTicket
    public class VIPTicket : Ticket
    {
        //properties
        public string AdditionalExtras { get; set; }
        public decimal AdditionalCost { get; set; }

        //constructors
        public VIPTicket()
        {
            
        }
        public VIPTicket(string name, decimal price, int availableTickets, string additionalExtras, decimal additionalCost)
            : base(name, price, availableTickets)
        {
            AdditionalExtras = additionalExtras;
            AdditionalCost = additionalCost;
        }

        //methods
        public override string ToString()
        {
            return $"{Name} - {Price + AdditionalCost:C} ({AdditionalExtras}) [AVAILABLE - {AvailableTickets}]";
        }
    }

    public class Event : IComparable<Event>
    {
        //properties
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public List<Ticket> Tickets { get; set; }
        public EventType TypeOfEvent { get; set; }

        //constructors
        public Event()
        {
            
        }
        public Event(string name, DateTime eventDate, EventType typeOfEvent, List<Ticket> tickets)
        {
            Name = name;
            EventDate = eventDate;
            TypeOfEvent = typeOfEvent;
            Tickets = tickets;
        }

        //methods
        // Implement IComparable
        public int CompareTo(Event other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.EventDate.CompareTo(other.EventDate);
        }

        public override string ToString()
        {
            return $"{Name} - {EventDate.ToShortDateString()}";
        }
    }
}
