# Pre-requisites
This project was tested with 
- .NET Core SDK: 8.0.300  (arm64)
- .NET Core Runtime: 8.0.5  (arm64) 

Download and install the corresponding .NET SDK and runtime

# How to run
1. Clone this repo: for example
```
git clone https://github.com/ceacosta-git/samplemstest
```
2. Navigate to `samplemstest` project on your local environment: for example
```
cd ~/dev/samplemstest
```
3. Run tests: for example,
```
dotnet test --filter AlternativeLoginTest
```  
# Tech Stack
- C#
- [Selenium](https://www.selenium.dev/documentation/)
- [MSTest](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)
# Test sampletest login

## Problem Statement
You have a web application with a login page containing username, password, and login button elements. 

Write a Selenium test script in C# that performs the following steps:

1. Open the web browser (e.g., Chrome).
2. Navigate to the login page:  `www.sampletest.com/login`
3. Enter valid credentials into textboxes with css ID’s `username` and `password`.
- Credentials:
    - Username: user
    - Password: testpassword
4. Click the `Login` button.
5. Verify successful login (e.g., check for a welcome message).
- css ID: successBanner – Message contains `Success`

** Add other test cases around this flow **

```
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class SampleTest
{
        //constructor
	Public SampleTest()
{
 	   
}

    //Test cases
}
```
## Solution
    
The main solution was implemented in [CanLoginToSampleTest](https://github.com/ceacosta-git/samplemstest/blob/main/SampleTest/LoginTest.cs)

Note: This test fails as the `www.sampletest.com/login` UI does not follow the design as stated in the `Problem Statement`

### Other test cases around this flow
I only implemented an additional (end-to-end) test case to showcase a non-happy path scenario in [LoginErrorsWhenCredentialsAreInvalid](https://github.com/ceacosta-git/samplemstest/blob/main/SampleTest/LoginTest.cs) 


There are multiple test scenarios for a `Login` feature. The following should be discussed to establish their `value`, `impact`, `priority` and how much to the `left` can we implement them. 
- What is the `unit tests` coverage with respect to Login requirements? 

    As e2e tests are more expensive, we could `shift-left` to unit test other non-happy Login paths. For example,

    | e2e | unit |
    | --- | --- |
    | wrong password| non-existing user |
    | | locked-out user |
    | | empty credentials |
    
- What are the requirements for `Credentials`? Some of the credentials requirements could `shift-left` to `component tests` in a design system `ui-components` repo setup with `jest`

    | e2e | unit/component |
    | --- | --- |
    | | character limits |
    | | invalid characters |
    | | empty credentials |

- What are the `performance` requirements? e.g., how long should we expect to get into a successful logged in state. Is there a timed-out UX? This could lead us in evaluating a need for `performance testing` and/or `API testing`.  
- What are the requirements, behavior, expectations regarding the user's session lifetimes and authentication mechanisms (e.g., CAPTCHA, Two-Factor-Authentication)? This could lead us in evaluating a need for `security testing`
- How much login/logout activity do we expect? This could lead us in evaluating a need for `load testing` and/or `monitoring`/`alerting`.  

## Alternative Solution
I included [LoginErrorsWhenAccountIsLocked](https://github.com/ceacosta-git/samplemstest/blob/main/SampleTest/AlternativeLoginTest.cs) to show that `samplemstest` project is a working solution. To run only this test:
```
dotnet test --filter LoginErrorsWhenAccountIsLocked
```

## ToDo's
There are some action items to be implemented for a more `production-like` solution.
- Simplify tests by implementing a Page Object Model for the Login page.
- Use a secure way to specify the password. For example, look into passing it through a configuration file, secrets file, environment variable.
- Look into how to run this project `samplemstest` in GitHub.
- Look into how to setup and run this project `samplemstest` using Docker.

## References
As a first experience working on C# and for a refresher on Selenium, the following references were extremely useful:
- [Getting started with Selenium](https://www.selenium.dev/documentation/webdriver/getting_started/)
- [Official Selenium .NET examples](https://github.com/SeleniumHQ/seleniumhq.github.io/tree/trunk/examples/dotnet)
