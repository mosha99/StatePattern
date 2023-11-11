namespace Mosha.StatePattern.Test.Unit.Models;

public class Person
{
    public Person(DateOnly birthDate, string name, string description)
    {
        BirthDate = birthDate;
        Name = name;
        Description = description;
        PersonState = new(PersonEducationEnum.NotYetGoToSchool);
    }

    // Only For Test
    public Person(DateOnly birthDate, string name, string description,  PersonEducationEnum personState )
    {
        BirthDate = birthDate;
        Name = name;
        Description = description;
        PersonState = new(personState);
    }

    public int Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public DateOnly BirthDate { get; private set; }

    public int Age => (DateTime.Now.Year - BirthDate.Year);

    public PersonEducationEnum State => PersonState.StateKey;
    public StateBehavior<IPersonState, PersonEducationEnum, PersonStateRule> PersonState { get;  set; } 

    public void Group(DateOnly birthDate)
    {
        BirthDate = birthDate;
    }

    public void GoToSchool()
    {
        if (!PersonState.State.CanGoToSchool(this))
        {
            throw new Exception("this person can't go to School");
        }

        PersonState = new(PersonEducationEnum.GoToSchool);
    }
    public void EndSchool()
    {
        if (!PersonState.State.CanEndSchool(this))
        {
            throw new Exception("this person can't end School");
        }
        PersonState = new(PersonEducationEnum.EndSchool);

    }
    public void GoToHighSchool()
    {
        if (!PersonState.State.CanGoToHighSchool(this))
        {
            throw new Exception("this person can't go to High School");
        }
        PersonState = new(PersonEducationEnum.GoToHighSchool);
    }
    public void EndHighSchool()
    {
        if (!PersonState.State.CanEndHighSchool(this))
        {
            throw new Exception("this person can't end High School");
        }
        PersonState = new(PersonEducationEnum.EndHighSchool);
    }
    public void GoToUniversity()
    {
        if (!PersonState.State.CanGoToUniversity(this))
        {
            throw new Exception("this person can't go to University");
        }
        PersonState = new(PersonEducationEnum.GoToUniversity);
    }

}