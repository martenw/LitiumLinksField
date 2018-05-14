# LitiumLinksField

Field definition for Litium PIM to show all links where a product is published

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

