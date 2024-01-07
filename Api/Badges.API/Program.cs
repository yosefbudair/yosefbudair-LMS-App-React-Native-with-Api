using Badges.Core.Common;
using Badges.Core.Repository;
using Badges.Core.Services;
using Badges.Infra.Common;
using Badges.Infra.Repository;
using Badges.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//AddScoped

// Add services to the container.q

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IDbContext, DbContext>();

//----------------------------------------------------- Repository -----------------------------------------------------

builder.Services.AddScoped<IBadgesRepository, BadgesRepository>();
builder.Services.AddScoped<ICourseTraineeRepository, CourseTraineeRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAssignmentTrainee_Repository, AssignmentTrainee_Repository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IJWTRepository, JWTRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAttendanceTrRepository, AttendanceTrRepository>();
builder.Services.AddScoped<IBadgesTrRepository,BadgesTrRepository >();

//----------------------------------------------------- Services -----------------------------------------------------

builder.Services.AddScoped<IBadgesService, BadgesService>();
builder.Services.AddScoped<ICourseTraineeService, CourseTraineeService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IAssignmentTraineeService, AssignmentTrainee_Service>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAttendanceTrService, AttendanceTrService>();
builder.Services.AddScoped<IBadgesTrServices,BadgesTrServices >();




builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SECRET USED TO SIGN AND VERIFY JWT TOKEN"))
       };
   });



var app = builder.Build();

app.UseAuthentication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
