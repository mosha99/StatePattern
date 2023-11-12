using Mosha.StatePattern.Ef;
using Mosha.StatePattern.Test.Models.States;

namespace Mosha.StatePattern.Test.Models.Models;

public class Person
{
    public Person(DateOnly birthDate, string name, string description)
    {
        BirthDate = birthDate;
        Name = name;
        Description = description;
        PersonBaseState = new(PersonEducationEnum.NotYetGoToSchool);
    }

    // Only For Test
    public Person(DateOnly birthDate, string name, string description,  PersonEducationEnum personState )
    {
        BirthDate = birthDate;
        Name = name;
        Description = description;
        PersonBaseState = new(personState);
    }

    public int Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public DateOnly BirthDate { get; private set; }

    public int Age => (DateTime.Now.Year - BirthDate.Year);

    public PersonEducationEnum State => PersonBaseState.StateKey;
    public EfDbStateBehavior<IPersonState, PersonEducationEnum, PersonStateRule> PersonBaseState { get;  set; } 

    public void SetBirthDate(DateOnly birthDate)
    {
        BirthDate = birthDate;
    }

    public void GoToSchool()
    {
        if (!PersonBaseState.State.CanGoToSchool(this))
        {
            throw new Exception("this person can't go to School");
        }

        PersonBaseState = new(PersonEducationEnum.GoToSchool);
    }
    public void EndSchool()
    {
        if (!PersonBaseState.State.CanEndSchool(this))
        {
            throw new Exception("this person can't end School");
        }
        PersonBaseState = new(PersonEducationEnum.EndSchool);

    }
    public void GoToHighSchool()
    {
        if (!PersonBaseState.State.CanGoToHighSchool(this))
        {
            throw new Exception("this person can't go to High School");
        }
        PersonBaseState = new(PersonEducationEnum.GoToHighSchool);
    }
    public void EndHighSchool()
    {
        if (!PersonBaseState.State.CanEndHighSchool(this))
        {
            throw new Exception("this person can't end High School");
        }
        PersonBaseState = new(PersonEducationEnum.EndHighSchool);
    }
    public void GoToUniversity()
    {
        if (!PersonBaseState.State.CanGoToUniversity(this))
        {
            throw new Exception("this person can't go to University");
        }
        PersonBaseState = new(PersonEducationEnum.GoToUniversity);
    }

}

