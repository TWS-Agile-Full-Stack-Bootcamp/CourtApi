# Test requirement: 
* Please only finish the implementation and test on Repository level. No need to consider Controller level. 
* For Repository level, you only need to test customized functions.
* Each AC should be committed once at least.
* TDD method should be applied.

# Story Analysis: 
## Story 1
As a court president, I need to file all the criminal cases. And to find a specific case by its case ID or case name. I also hope to find all the related cases. And cancel or delete a case by its case ID.
### AC1:  
Each criminal case has an ID automatically created and a character string between 0-255 characters as its case name. The milliseconds since January 1st, 1970 will be set as the time of the case.
All the items except ID should be "cannot be null", otherwise data cannot be saved.

### AC2: 
By providing the case ID, you can find all the information related to this case, including its ID, case name and the time of the case.

### AC3: 
All the cases and the related details can be found (including ID, case name and the time of the case) on one search, and can also be ranked in the order of case time.

### AC4
By providing the case name, you can find all the related information, including its ID, case name and the time of the case.(The search results may be more than one case)

### AC5
You can delete the related cases by providing the case ID.

——————————————————————————————————————————

## Story 2
As a court president, I hope to file and save the crime components of the case based on story1. The components include: 
A crime component ID which is automatically created.
A character string between 0-255 characters as the description for the objective case  component.
A character string between 0-255 characters as the description for the subjective case component.

### AC1:  
Case details include an automatically created ID, the subjective and objective components. The subjective and objective components shouldn't be null.

### AC2: 
By providing the ID of case details, you can find all the corresponding case details, including ID, subjective and objective components.

### AC3: 
For each case,, its basic information and specific information should match each other. 

### AC4: 
For any criminal case you have found, you can add case details.
——————————————————————————————————————————

## Story 3.1
As a court president, I hope to file and save the corresponding procuratorate information based on story1. 

### AC1:  
For procuratorate, it has an automatically created ID and a character string between 0-50 characters as its name. The name shouldn't be null. There shouldn't be any repetitions for procuratorate names.

### AC2: 
By searching procuratorate ID, you can find the corresponding procuratorate information, including its ID and name.

### AC3: 
Each case should have a corresponding procuratorate as its prosecuting party. The procuratorate information for each case should not be null. 

### AC4: 
For any criminal case you have found, you can add procuratorate information.

——————————————————————————————————————————

## Story 3.2
As a court president, I hope to add prosecutor's descriptions based on story3.1.

### AC1: 
For prosecutor, it should have an automatically created ID and a name between 0-255 characters. Names shouldn't be null.

### AC2: 
By searching prosecutor ID, you can find related prosecutor information, including its ID and name.

### AC3: 
A procuratorate may have many prosecutors. By searching for a certain procuratorate, you can find the corresponding prosecutor information.


# hint
* MySql Connection string: `server=localhost;user=root;database=db;password=*****;`
* Use below code to method of `Configure` in file `Startup.cs` to create database automaticlly
```

using (var scope = app.ApplicationServices.CreateScope())
{
    using (var context = scope.ServiceProvider.GetService<CompanyDBContext>())
    {
        context.Database.EnsureCreated();
    }
}
```
* create database context
* inject database context then call its save & findAll in resource
* To no run test parallel, add annotation to test class: `[Collection("Collection #1")]`

