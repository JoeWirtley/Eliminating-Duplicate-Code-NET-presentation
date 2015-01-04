Eliminating Duplicate Code
=====================================

This project contains the sample code for the eliminating duplicate code 
presentation.  Each folder contains an example of how to eliminate one 
type of duplicate code with Original and Refactored folders showing
the code before and after duplicate code removal.  Most folder also have
a Support folder containing classes used by both the original and
refactored code, and a Test folder with unit tests demonstrating the 
code functions the same before and after.

The examples demonstrate the following code duplication patterns.  The
number in parentheses is the example number corresponding to the specific
type of duplication:

------------------------------------------

* **Same**
   * Method
   * Class (1)

------------------------------------------
* **Same except for location**
   * Related to Type
      * Encapsulation   
         * Method/Property (2)
         * Class hierarchy (3)
      * Extension method (4)
   * Before/After
      * Delegate (5)
      * Attribute (6)
      * AOP

------------------------------------------
* **Same except for type**
   * Generics
      * Method (7)
      * Type (8)


------------------------------------------
