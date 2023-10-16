﻿using Mosha.StatePatter.Test.Model.Deal.States.Interface;

namespace Mosha.StatePatter.Test.Model.Deal.States;

public class DealConfirmed : IDealState
{
    public bool CanRevoked(Deal deal) => true;
}