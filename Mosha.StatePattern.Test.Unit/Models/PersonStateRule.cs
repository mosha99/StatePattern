namespace Mosha.StatePattern.Test.Unit.Models;

public class PersonStateRule : StateRule<PersonEducationEnum>
{
    public PersonStateRule()
    {
        AddRule<NotYetGoToSchoolState>(PersonEducationEnum.NotYetGoToSchool);
        AddRule<GoToSchoolState>(PersonEducationEnum.GoToSchool);
        AddRule<EndOfSchoolState>(PersonEducationEnum.EndSchool);
        AddRule<GoToHighSchoolState>(PersonEducationEnum.GoToHighSchool);
        AddRule<EndHighSchoolState>(PersonEducationEnum.EndHighSchool);
        AddRule<GoToUniversityState>(PersonEducationEnum.GoToUniversity);
    }
}