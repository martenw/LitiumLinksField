# LitiumLinksField

Field definition for Litium PIM to show all links where a product/category is published.

A similar view was avaliable in Litium before version 5 but has now been removed. Useful also to display all valid URL's that a product/category has.

Example:

![Links field example](/screenshots/linksfield.png?raw=true "Links field example") 

## Installation instructions

The four needed source files can be found in /src folder.

1. Copy the files from \src to the following paths in Litium Accelerator solution and build the project 
```
\src\Litium.Accelerator\FieldFramework\LinksField.cs
\src\Web\Site\Administration\Api\Controllers\UrlInfoController.cs
\src\Web\Site\Administration\FieldFramework\accelerator_linksEdit.js
\src\Web\Site\Administration\FieldFramework\LinksEdit.html
```
2. In Litium backoffice create a new instance of the now avaliable `Links` fieldtype
3. Add the new field to all product and category templates

