namespace WinterwireGames.MaterialParameters
{
	public class FloatMaterialParameter : MaterialParameter<float>
	{
		public override float MaterialValue 
		{
			get => this.Material.GetFloat(this.ParameterName);
			set => this.Material.SetFloat(this.ParameterName, value);
		}
	}
}
