Feature: Wishlist regression
	As a new customer
	I want to be able to create an account on "automationpractice.com"
	So I can add an item to my wish list

Background:
	Given I am on the home page
	When I click a 'Sign in' button
	Then I should be redirected to 'Sign in' page
	
# 6.	I can See “MY WISHLISTS”  link.
@regression
Scenario: Logged in customer can see 'MY WISHLISTS' link on 'My Account' page
	Given I am user John Kowalski
	When I log in to my account
	Then I am on 'MY ACCOUNT' page 
	And I can see 'MY WISHLISTS' link on the page

# 8.	I can see “TOP SELLERS” list on left side panel.
@regression
Scenario: Logged in customer can see 'Top sellers' link on 'My Wishlists' page
	Given I am user John Kowalski
	When I log in to my account
	And I click on 'MY WISHLISTS' link
	Then I can see 'TOP SELLERS' list on the left side panel
	
# 10.	I can see “Add to wishlist” under “Add to cart” button.
@regression
Scenario: Logged in customer can see 'Add item to his wishlist' button
	Given I am user John Kowalski
	When I log in to my account
	And I click on 'MY WISHLISTS' link
	And I click on the first item in 'TOP SELLERS' list
	Then I can see 'Add an item to my wishlist' button under 'Add to cart' button