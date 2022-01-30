using Challenge.Core.Context;
using Challenge.Core.Models;
using Challenge.Core.Query;
using Challenge.Core.UseCases;
using Challenge.Core.Validations;
using Challenge.UseCases.ClassesUseCases.AddCountryUseCase;
using Challenge.UseCases.ClassesUseCases.DeleteClassUseCase;
using Challenge.UseCases.ClassesUseCases.UpdateClassUseCase;
using Challenge.UseCases.ClassesUseCases.ViewClassListUseCase;
using Challenge.UseCases.CountriesUseCases.AddCountryUseCase;
using Challenge.UseCases.CountriesUseCases.DeleteCountryUseCase;
using Challenge.UseCases.CountriesUseCases.UpdateCountryUseCase;
using Challenge.UseCases.CountriesUseCases.ViewCountriesUseCase;
using Challenge.UseCases.CountryUseCases.AddStudentUseCase;
using Challenge.UseCases.CountryUseCases.DeleteStudentUseCase;
using Challenge.UseCases.StudentsUseCases.UpdateStudentUseCase;
using Challenge.UseCases.StudentsUseCases.ViewStudentsUseCase;
using Challenge.Validations.ClassExistanceValidator;
using Challenge.Validations.CountryValidators;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped(typeof(IQuery<student_record>), typeof(StudentQuery));
builder.Services.AddScoped(typeof(IQuery<country_record>), typeof(CountryQuery));
builder.Services.AddScoped(typeof(IQuery<class_record>), typeof(ClassQuery));

builder.Services.AddScoped(typeof(UseCase<AddStudentRequest,AddStudentResponse>), typeof(AddStudentUseCase));
builder.Services.AddScoped(typeof(UseCase<DeleteStudentRequest,DeleteStudentResponse>), typeof(DeleteStudentUseCase));
builder.Services.AddScoped(typeof(UseCase<UpdateStudentRequest,UpdateStudentResponse>), typeof(UpdateStudentUseCase));
builder.Services.AddScoped(typeof(UseCase<ViewStudentRequest,ViewStudentResponse>), typeof(ViewStudentUseCase));

builder.Services.AddScoped(typeof(UseCase<UpdateCountryRequest,UpdateCountryResponse>), typeof(UpdateCountryUseCase));
builder.Services.AddScoped(typeof(UseCase<AddCountryRequest,AddCountryResponse>), typeof(AddCountryUseCase));
builder.Services.AddScoped(typeof(UseCase<DeleteCountryRequest,DeleteCountryResponse>), typeof(DeleteCountryUseCase));
builder.Services.AddScoped(typeof(UseCase<ViewCountriesRequest,ViewCountriesResponse>), typeof(ViewCountryUseCase));


builder.Services.AddScoped(typeof(UseCase<AddClassRequest,AddClassResponse>), typeof(AddClassUseCase));
builder.Services.AddScoped(typeof(UseCase<UpdateClassRequest,UpdateClassResponse>), typeof(UpdateClassUseCase));
builder.Services.AddScoped(typeof(UseCase<DeleteClassRequest,DeleteClassResponse>), typeof(DeleteClassUseCase));
builder.Services.AddScoped(typeof(UseCase<ViewClassListRequest,ViewClassListResponse>), typeof(ViewClassListUseCase));

builder.Services.AddScoped(typeof(ExistanceValidation<country_record>), typeof(CountryExistanxeValidator));
builder.Services.AddScoped(typeof(ExistanceValidation<class_record>), typeof(ClassExistanceValidator));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("corsapp");
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
