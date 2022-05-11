using Validators;
using System.Reflection;
using Newtonsoft.Json;
namespace Program;

public class Advertisement
{
	private int _ID;
	private int _price;
	private string _title;
	private string _transaction;
	private string _website_url;
	private string _photo_url;
	private DateTime _start_date;
	private DateTime _end_date;

	private Dictionary<string, string> _errors = new Dictionary<string, string>();
		public Advertisement()
		{
		}
		public Advertisement(
			string ID,
			string price,
			string title,
			string transaction,
			string photo_url,
			string website_url,
			DateTime start_date,
			DateTime end_date
		)
		{
			this.ID = int.Parse(ID);
			this.Price = int.Parse(price);
			this.Title = title;
			this.Transaction = transaction;
			this.PhotoURL = photo_url;
			this.WebsiteURL = website_url;
			this.StartDate = start_date;
			this.EndDate = start_date;
			return;
		}

		public static List<string> Keys
		{
			get
			{
				return new List<string>(new[] {
					"ID",
					"Price",
					"Title",
					"Transaction",
					"PhotoURL",
					"WebsiteURL",
					"StartDate",
					"EndDate"
				});
			}
		}

		public void AddError(string _field, string _msg)
		{
			this._errors.Add(_field, _msg);
		}
		
		[JsonIgnore]
		public Dictionary<string, string> Errors
		{
			get => _errors;
		}

		public int ID
		{
			get => this._ID;
			set
			{
				if (IntValidators.GreaterThanZero(value.ToString()) is null)
					this._errors.Add("ID", "ID is NULL or incorrect");
				else
					this._ID = value;

			}
		}
		public int Price
		{
			get => this._price;
			set
			{
				if (IntValidators.GreaterThanZero(value.ToString()) is null)
					this._errors.Add("Price", "Price is NULL or incorrect");
				else
					this._price = value;
			}
		}
		public string Title
		{
			get => this._title;
			set
			{
				if (StringValidators.IsTitle(value.ToString()) is null)
					this._errors.Add("Title", "Title is NULL or incorrect (title starts from uppercase)");
				else
					this._title = value;
			}
		}
		public string Transaction
		{
			get => this._transaction;
			set
			{
				if (StringValidators.IsTransactionNumber(value.ToString()) is null)
					this._errors.Add("Transaction", "Transaction is NULL or incorrect (format <XX-YYY-XX/YY> where 'X' is letter and 'Y' is number)");
				else
					this._transaction = value;
			}
		}
		public string PhotoURL
		{
			get => this._photo_url;
			set
			{
				if (StringValidators.IsUrl(value.ToString()) is null)
					this._errors.Add("Photo_URL", "Photo URL is NULL or incorrect");
				else
					this._photo_url = value;
			}
		}
		public string WebsiteURL
		{
			get => this._website_url;
			set
			{
				if (StringValidators.IsUrl(value.ToString()) is null)
					this._errors.Add("Website_URL", "Website URL is NULL or incorrect");
				else
					this._website_url = value;
			}
		}
		public DateTime StartDate
		{
			get => this._start_date;
			set
			{
				this._start_date = value;
			}
		}
		public DateTime EndDate
		{
			get => this._end_date;
			set
			{
				if (value < this._start_date)
					this._errors.Add("End_Date", "End date can't be earlier than start date");
				else
					this._end_date = value;
			}
		}

		public override string ToString()
		{
			string repr = "";

			foreach (PropertyInfo property in this.GetType().GetProperties())
			{
				if (!Advertisement.Keys.Contains(property.Name))
					continue;
				repr += property.Name + ": " + Convert.ToString(property.GetValue(this));
				repr += "\n";
			}
			return repr;
		}

		public bool Contains(string expr)
		{
			foreach (PropertyInfo property in this.GetType().GetProperties())
			{
				string strValue = Convert.ToString(property.GetValue(this));
				if (strValue.Contains(expr))
					return true;
			}
			return false;
		}
	}