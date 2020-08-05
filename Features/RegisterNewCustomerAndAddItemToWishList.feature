Feature: Register New Customer and ADD Item to wish list
	As a new customer
	I want to be able to create an account on "automationpractice.com"
	So I can add an item to my wish list

# 1.	There is a link to Sign in on the home page which leads customer to sign In page on click.
# 2.	Verify that user is not logged in
# 3.	Separate StepsClass for 'User'?
# 4.	What should I do with 'Authentication Page' after finishing test?
@regression
Scenario: Unlogged user can go to 'Sign In' page
	Given I am on the home page
	When I click a 'Sign in' button
	Then I should be redirected to 'Sign in' page

# 2.	I can create an account by entering an email address and clicking “create an account” button.
# 3.	I can enter my personal details on the registration form, including: title, first name, surname, address, city, state, zip/postal code, country, mobile phone and address alias 
# 4.	On submitting the registration, I am logged in and taken to a ‘my account’ page
# 5.	I can see my name top right corner.
@regression
Scenario Outline: New customer can register with email address
	Given I am on the 'Sign in' page
	When I enter my e-mail address to create a new account
	And I click a 'Create An Account' button
	And I enter personal details in registration form
	| Title   | FirstName    | LastName  | Address   | DateOfBirth   | City		| State		| PostalCode	| Country	| MobilePhone		| AddressAlias		|
	| <Title> | <First name> | <Surname> | <Address> | <DateOfBirth> |<City>	| <State>	| <Postal Code>	| <Country>	| <Mobile phone>	| <Address alias>	|
	And I click a 'Register' button
	Then I am redirected to 'My Account' page
	And I can see my name in the top right corner
	
	Examples:
	| Title | First name | Surname  | Address          | DateOfBirth	| City		| State		| Postal Code	| Country		| Mobile phone | Address alias	|
	| Mr.	| John       | Kowalski | Beautiful Street | 01-01-1970		| Opole		| Arizona	| 12345			| United States | +48123456789 | House address	|
	| Mrs.  | Eqtek      | User     | Wielicka 28B     | 12-12-1989		| Krakow	| Utah		| 30552			| United States	| +48123456789 | Work address	|

# 7.	I can click on “MY WISHLISTS” link.
# 9.	I can click on first item in “TOP SELLERS” list.
# 11.	I can add an item to my wish list.
# 12.	Application should confirm that item added to wish list.
# 13.	I can confirm that item added in “MY WISHLIST” by visiting “ MY WISHLIST” page.
@new
Scenario Outline: New user can add an item to his wishlist
	Given I am on the home page
	When I click a 'Sign in' button
	And I enter my e-mail address to create a new account
	And I click a 'Create An Account' button
	And I enter personal details in registration form
	| Title   | FirstName    | LastName  | Address   | DateOfBirth   | City		| State		| PostalCode	| Country	| MobilePhone		| AddressAlias		|
	| <Title> | <First name> | <Surname> | <Address> | <DateOfBirth> | <City>	| <State>	| <Postal Code>	| <Country>	| <Mobile phone>	| <Address alias>	|
	And I click a 'Register' button
	And I click on 'MY WISHLISTS' link
	And I click on the first item in 'TOP SELLERS' list
	And I add an item to my wishlist
	Then I receive a confirmation that item was added to my wishlist 
	And I navigate to my wishlist
	And I can see this item in my wishlist
	
	Examples:
	| Title | First name | Surname  | Address          | DateOfBirth	| City		| State		| Postal Code	| Country		| Mobile phone | Address alias	|
	| Mr.	| John       | Kowalski | Beautiful Street | 01-01-1970		| Opole		| Arizona	| 12345			| United States | +48123456789 | House address	|
	| Mrs.  | Eqtek      | User     | Wielicka 28B     | 12-12-1989		| Krakow	| Utah		| 30552			| United States	| +48123456789 | Work address	|