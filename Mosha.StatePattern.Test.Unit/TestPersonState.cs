using Mosha.StatePattern.Test.Unit.Models;

namespace Mosha.StatePattern.Test.Unit;

public class TestPersonState
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
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        if (person.State == PersonEducationEnum.GoToSchool) Assert.Pass();

        try
        {
            person.EndSchool();
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        if (person.State == PersonEducationEnum.EndSchool) Assert.Pass();

        try
        {
            person.EndHighSchool();
            Assert.Fail();
        }
        catch (Exception e)
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
        catch (Exception e)
        {
            Assert.Pass();
        }

        Assert.Fail();

    }

}