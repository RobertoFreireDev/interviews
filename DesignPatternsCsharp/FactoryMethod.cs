using System;					
public class RunFactoryMethod : IDesingPattern
{
    public void Run()
	{
		ICharacter player;
		player = FactoryMethod.Choose(CharacterEnum.Luigi);
		player.choosed();
	}
}

public class FactoryMethod
{
	public static ICharacter Choose(string characterName)
	{
		switch (characterName){
			case CharacterEnum.Luigi:
				return new Luigi();
			case CharacterEnum.Mario:
				return new Mario();
				default: return null;
		}
	}
}

public interface ICharacter
{
	void choosed();
}

public class Mario : ICharacter
{
    public void choosed()
    {
		Console.WriteLine("It is Mario!");
    }
}

public class Luigi : ICharacter
{
    public void choosed()
    {
		Console.WriteLine("It is Luigi!");
    }
}

public static class CharacterEnum
{
	public const string Mario = "Mario";
	public const string Luigi = "Luigi";
}