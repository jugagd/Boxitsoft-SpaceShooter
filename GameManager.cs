//Singleton reference
static public GameManager s_Instance;

private void Awake()
{
	//Sets up the singleton instance
	s_Instance = this;
}