namespace Juicios.Classes
{
	public class CaseItem
	{
		protected string _type = "Civil";
		protected string _name = "Expediente";
		protected bool _active = true;

		public string Type { get { return _type; } set { _type = value; } }
		public string Name { get { return _name; } set { _name = value; } }
		public bool Active { get { return _active; } set { _active = value; } }

		public CaseItem(string Type, string name, bool active)
		{
			this.Type = Type;
			this.Name = name;
			this.Active = active;
		}

	}
}
