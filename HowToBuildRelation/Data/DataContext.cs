﻿using HowToBuildRelation.Models;
using Microsoft.EntityFrameworkCore;

namespace HowToBuildRelation.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) 
    { }

    public DbSet<Character> Characters { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
}