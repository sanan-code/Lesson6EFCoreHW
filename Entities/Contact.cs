﻿namespace HomeTask3.Entities;

public class Contact
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public Customer Customer { get; set; }
}
