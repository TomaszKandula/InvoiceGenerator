# Invoice Generator

This repository holds application (API) that allows to generate an invoice. It uses invoice templates found in a separate repository: [Invoice Templates](https://github.com/TomaszKandula/InvoiceTemplates).

The project have single Web API and one worker (Azure Function). Web API allows to add new invoices for processing and uploading invoice templates to be used for invoices to be generated.

API project and worker project require Docker. Both are pushed to Azure: Azure App Service and Azure Functions.

## Backend

Backend projects:
1. Core - non-business related code, shared among other projects.
2. Cqrs - handlers (command and queries) with validators and manual mappers.
3. Database - self-explanatory.
4. Domain - contracts, entities and enums.
5. Shared - common code shared across other projects (DTOs and resources).

## Services

Services projects:
1. Batch service - order new invoice processing, execute processing, getting status, getting generated invoice.
2. Behaviour service - executes code before handler code is executed (validation, logging among others).
3. Template service - CRUD operations on invoice templates used to generate invoice.
4. User service - managing user account.
5. Vat service - VAT validation (Polish and European).

## Controllers

Key controllers delivering main capabilities:

1. Batches controller
2. Templates controller

Private key is necessary to query API. Each user have assigned its API key.

## End note

User management will be extended. 
