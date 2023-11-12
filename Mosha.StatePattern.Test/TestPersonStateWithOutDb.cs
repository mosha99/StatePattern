

using Mosha.StatePattern.Test.Models.Models;
using Mosha.StatePattern.Test.Models.States;

namespace Mosha.StatePattern.Test.Unit;

public class TestPersonStateWithOutDb
{
    [Test]
    public void TestOfMachineState()
    {
        var person = new Person(DateOnly.FromDateTime(DateTime.Now.AddYears(-18)), "moein", "hi i moein", PersonEducationEnum.NotYetGoToSchool);

        if (person.State != PersonEducationEnum.NotYetGoToSchool) Assert.Fail();

        try
        {
            person.GoToSchool();
        }
        catch (Exception)
        {
            Assert.Fail();
        }
        if (person.State == PersonEducationEnum.GoToSchool) Assert.Pass();

        try
        {
            person.EndSchool();
        }
        catch (Exception)
        {
            Assert.Fail();
        }
        if (person.State == PersonEducationEnum.EndSchool) Assert.Pass();

        try
        {
            person.EndHighSchool();
            Assert.Fail();
        }
        catch (Exception)
        {

        }
        Assert.Pass();

    }

    [Test]
    public void TestGoToUni()
    {
        var person = new Person(DateOnly.FromDateTime(DateTime.Now.AddYears(-8)), "moein", "hi i moein", PersonEducationEnum.NotYetGoToSchool);

        if (person.State != PersonEducationEnum.NotYetGoToSchool) Assert.Fail();

        try
        {
            person.GoToUniversity();
        }
        catch (Exception)
        {
            Assert.Pass();
        }

        Assert.Fail();

    }

}