namespace Juicios.Classes
{
	public class CaseItem
	{
		protected string _type = "Civil";
		protected string _name = "Expediente";
		protected bool _active = true;

		public string type { get { return _type; } set { _type = value; } }
		public string name { get { return _name; } set { _name = value; } }
		public bool active { get { return _active; } set { _active = value; } }

		public CaseItem(string type, string name, bool active)
		{
			this.type = type;
			this.name = name;
			this.active = active;
		}
	}
}
