﻿namespace Sales.Backoffice.WebApi.Models;

public class AssignedToAnAgent : EntityBase
{
    public Agent Agent { get; set; }
    public Guid AgentId { get; set; }
}