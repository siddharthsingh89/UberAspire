namespace UberAspire.RiderApp.Views.Components;

public partial class SearchLocationSuggestionView : ContentView
{
	public List<Monkey> Monkeys { get; set; }
	public SearchLocationSuggestionView()
	{
		InitializeComponent();
        Monkeys = new List<Monkey>();
        Monkeys.Add(new Monkey { Name = "Baboon", Location = "Africa & Asia" });
        Monkeys.Add(new Monkey { Name = "Capuchin Monkey", Location = "Central & South America" });
        Monkeys.Add(new Monkey { Name = "Blue Monkey", Location = "Central and East Africa" });


		BindingContext = Monkeys;
	}

	public class Monkey
	{
		public string Name { get; set; }
        public string Location { get; set; }

    }
}