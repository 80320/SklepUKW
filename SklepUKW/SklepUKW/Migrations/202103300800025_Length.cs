namespace SklepUKW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Length : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "FilmLength", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "FilmLength");
        }
    }
}
