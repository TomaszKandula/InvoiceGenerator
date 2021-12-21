# [1.5.0](https://github.com/TomaszKandula/InvoiceGenerator/compare/v1.4.0...v1.5.0) (2021-12-21)


### Features

* add Azure Functions to the solution ([955152e](https://github.com/TomaszKandula/InvoiceGenerator/commit/955152ec1d51e1552ec6ab13e16f0447e1216a7d))
* add startup configuration ([650ba99](https://github.com/TomaszKandula/InvoiceGenerator/commit/650ba99cdf7d7161d548f9f8b323a66140d9c1f2))
* add worker implementation for invoice processing ([d446b40](https://github.com/TomaszKandula/InvoiceGenerator/commit/d446b40321d888dbe3c5698b51a4ee06a4af2d84))

# [1.4.0](https://github.com/TomaszKandula/InvoiceGenerator/compare/v1.3.1...v1.4.0) (2021-12-15)


### Features

* add Azure Functions to workers solution folder ([18f9fdc](https://github.com/TomaszKandula/InvoiceGenerator/commit/18f9fdc297c40b7b1ac3ee9e043c1fae90b044c0))

## [1.3.1](https://github.com/TomaszKandula/InvoiceGenerator/compare/v1.3.0...v1.3.1) (2021-12-14)


### Bug Fixes

* filter invoice items, return items per order ID ([57f19ac](https://github.com/TomaszKandula/InvoiceGenerator/commit/57f19ac61bec413d31c44c2b0cf59d7e1530e7ce))

# [1.3.0](https://github.com/TomaszKandula/InvoiceGenerator/compare/v1.2.0...v1.3.0) (2021-12-14)


### Bug Fixes

* add missing description ([9a6dfda](https://github.com/TomaszKandula/InvoiceGenerator/commit/9a6dfda58b2f70c569a650753fca14d97bc75d4b))
* change incorrect file upload implementation ([171eb5c](https://github.com/TomaszKandula/InvoiceGenerator/commit/171eb5c5f94913481b53bb019e82aa4137e3d92b))
* correct filed names ([0699afe](https://github.com/TomaszKandula/InvoiceGenerator/commit/0699afefc7d5fffe65f701cf1bc5b85bf3f8a7a9))
* object should be created for each new order ([cba1f23](https://github.com/TomaszKandula/InvoiceGenerator/commit/cba1f233b28e8a4ed7aaa5b53d6af70ffc3ec458))


### Features

* add batch processing order ([aeb9648](https://github.com/TomaszKandula/InvoiceGenerator/commit/aeb9648333ac92fc1451f80044c733cd6520663d))
* add columns to database table ([38312f7](https://github.com/TomaszKandula/InvoiceGenerator/commit/38312f7a0fe0409473b4a23721d51ea6fe353085))
* add configuration for new constraints ([6e22dd2](https://github.com/TomaszKandula/InvoiceGenerator/commit/6e22dd221bb94b784eba9020335cd81d07c8e33f))
* add currency code to database tables ([ac5c6e5](https://github.com/TomaszKandula/InvoiceGenerator/commit/ac5c6e5cd991d1fd5becb975bf56f96fe6ad79c8))
* add currency code to user bank accounts table ([df94046](https://github.com/TomaszKandula/InvoiceGenerator/commit/df94046c915392a0bf493133dc365545c41844c9))
* add custom string to enum converter ([f726f10](https://github.com/TomaszKandula/InvoiceGenerator/commit/f726f10f34540de426043b4b5d286af198b29e2d))
* add endpoint to call batch processing ([112cd79](https://github.com/TomaszKandula/InvoiceGenerator/commit/112cd7973c997260b3af87797184809108df369d))
* add migration ([614bead](https://github.com/TomaszKandula/InvoiceGenerator/commit/614bead524d92401718e5ef683514991d8e83496))
* add migration of currency code (change in database) ([af86c54](https://github.com/TomaszKandula/InvoiceGenerator/commit/af86c545e1c0922fa0adee1c4ffff622c3a06609))
* add new columns to user companies database table ([5e6cfda](https://github.com/TomaszKandula/InvoiceGenerator/commit/5e6cfda1c114faedfa24168362604bd526b584a8))
* add new error codes ([7afe705](https://github.com/TomaszKandula/InvoiceGenerator/commit/7afe7053ba46230d3d5b0595c8b58acebf67ad6d))
* add new exception for invoice processing ([efc3061](https://github.com/TomaszKandula/InvoiceGenerator/commit/efc3061cba337a03c8622af06e9a21ab3d47844c))
* add new models for invoice batch processing ([99edde9](https://github.com/TomaszKandula/InvoiceGenerator/commit/99edde9c16b46a0b794a3689c242b1eb858698ea))
* add outstanding invoice processing ([6b4c8ee](https://github.com/TomaszKandula/InvoiceGenerator/commit/6b4c8eeaed5a09b2f9ec04e51741a6d4e2f2f8a8))
* add payment status column to database table ([7c6a144](https://github.com/TomaszKandula/InvoiceGenerator/commit/7c6a144c24354fcc20cd3c2b34d26718cdfdc815))
* add payments status to order new batch invoice ([1a37145](https://github.com/TomaszKandula/InvoiceGenerator/commit/1a37145a55f5a8564fdc99fbea74fcf7ccd5e35f))
* apply currency and date formatting ([6259299](https://github.com/TomaszKandula/InvoiceGenerator/commit/625929922fa0ca87d791fe10f40953f9e11fcf7d))
* map new properties ([4a43703](https://github.com/TomaszKandula/InvoiceGenerator/commit/4a4370371d650769291a00b2e1929d3ea0da66c6))
* simplify invoice processing implementation ([1251357](https://github.com/TomaszKandula/InvoiceGenerator/commit/125135712a7099d343e68e156af6a9d237ac3672))
* upgrade implementation to follow other changes ([cfb4dfd](https://github.com/TomaszKandula/InvoiceGenerator/commit/cfb4dfde0df190445a3386bd7111814234cdd013))
* use json converter attribute ([80b5a0e](https://github.com/TomaszKandula/InvoiceGenerator/commit/80b5a0e435f3c211d386bec6aaa2a30cbefaf4d6))

# [1.2.0](https://github.com/TomaszKandula/InvoiceGenerator/compare/v1.1.0...v1.2.0) (2021-12-11)


### Features

* add new endpoints ([a05f1ee](https://github.com/TomaszKandula/InvoiceGenerator/commit/a05f1ee7f82e3b40c2e3fa2c73cf93aa2a556f7a))
* split domains endpoints into separate endpoints under new controllers ([b44c363](https://github.com/TomaszKandula/InvoiceGenerator/commit/b44c36369047213ecdb2fee6e1f8a45c6576cd47))

# [1.1.0](https://github.com/TomaszKandula/InvoiceGenerator/compare/v1.0.0...v1.1.0) (2021-12-11)


### Bug Fixes

* add missing condition to filter out soft deleted items ([2069d31](https://github.com/TomaszKandula/InvoiceGenerator/commit/2069d3181789277430900345c92d7205a93a7579))
* rename argument, place it in endpoint route ([068489a](https://github.com/TomaszKandula/InvoiceGenerator/commit/068489aff22e9a85d65e8d233a7528f1c41feeec))


### Features

* add new DTO ([c86a238](https://github.com/TomaszKandula/InvoiceGenerator/commit/c86a238e14bf98d2ffe1cab9077596a4ff87b0b7))

# 1.0.0 (2021-12-11)


### Bug Fixes

* add missing null checks ([fb4fe98](https://github.com/TomaszKandula/InvoiceGenerator/commit/fb4fe98c06d3e4fe9fa273be9c210ee65c97ac58))
* add missing service registration ([58f204f](https://github.com/TomaszKandula/InvoiceGenerator/commit/58f204f86322f9255dab5ce1c10c17b250ed4546))
* add version number, use string interpolation ([33318d1](https://github.com/TomaszKandula/InvoiceGenerator/commit/33318d100ab7d86ceb56ef7ee0546b6071610654))
* remove old docker file ([8ac9679](https://github.com/TomaszKandula/InvoiceGenerator/commit/8ac9679b7d8b6c7a56b4c9fe08cf0971f88e9394))
* remove required attribute from property ([907837d](https://github.com/TomaszKandula/InvoiceGenerator/commit/907837dbaeff6901b834ecdda53baadbd9118478))
* remove whitespace from docker file ([9254eae](https://github.com/TomaszKandula/InvoiceGenerator/commit/9254eae61aff1af202f4b947978fecb433e20845))


### Features

* ad new error code for invalid api reference ([7925997](https://github.com/TomaszKandula/InvoiceGenerator/commit/792599748ead9552fa8d0403d8b517e783e7fa4e))
* add column, add migration ([5612243](https://github.com/TomaszKandula/InvoiceGenerator/commit/5612243780ed28c75407908d067cfa7819091ed0))
* add columns to database tables ([9d6f8e8](https://github.com/TomaszKandula/InvoiceGenerator/commit/9d6f8e81a92925f71457ac5f3d4486b64c518642))
* add configuration ([edfd9cd](https://github.com/TomaszKandula/InvoiceGenerator/commit/edfd9cd3a4eb04f647edd2b80de00fcab6483d0d))
* add contracts ([267d1c5](https://github.com/TomaszKandula/InvoiceGenerator/commit/267d1c56eb40ed55cd5c6977b90c6afbe4accad7))
* add controller for invoice template CRUD operations ([fb1796e](https://github.com/TomaszKandula/InvoiceGenerator/commit/fb1796ef7d7e49e614da86a7c90c99ea1de28f89))
* add CORE service ([aaaeeb3](https://github.com/TomaszKandula/InvoiceGenerator/commit/aaaeeb338d5bee78eb19f4d6cf180efdf53ff5aa))
* add cqrs and validator ([76b3bf8](https://github.com/TomaszKandula/InvoiceGenerator/commit/76b3bf8787e931bf899c186c75da5c7ec555ab7a))
* add cqrs for adding invoice template, add validator ([004d627](https://github.com/TomaszKandula/InvoiceGenerator/commit/004d627a8c03c0de98b2860bb3621d2b61e2e5cf))
* add cqrs for getting country codes ([cdeeb9c](https://github.com/TomaszKandula/InvoiceGenerator/commit/cdeeb9c54b1495118d218fd17200f897d6b0df01))
* add cqrs for getting currency codes ([f6a3ab6](https://github.com/TomaszKandula/InvoiceGenerator/commit/f6a3ab6a7478132d91a7ba8253267b8cd8491f82))
* add cqrs for getting invoice batch processing status ([bf8258c](https://github.com/TomaszKandula/InvoiceGenerator/commit/bf8258c9844e9d3690bf3e96c39fb705edad3346))
* add cqrs for getting invoice template, add validator ([095aab8](https://github.com/TomaszKandula/InvoiceGenerator/commit/095aab83186c873fe5c3d94af36921ca55719c62))
* add cqrs for getting invoice templates, add validator ([4bb3c0a](https://github.com/TomaszKandula/InvoiceGenerator/commit/4bb3c0ae0ef1b8480d2f7eb311ee45e4b9ba7e70))
* add cqrs for getting issued invoice from database ([47e4e2e](https://github.com/TomaszKandula/InvoiceGenerator/commit/47e4e2ea73e6088a56808cc37354e2660fee78d5))
* add cqrs for getting payment statuses ([e576dca](https://github.com/TomaszKandula/InvoiceGenerator/commit/e576dca73cfcdc8fa447d736769673b90e31c1e8))
* add cqrs for getting payment types ([6ac3ee7](https://github.com/TomaszKandula/InvoiceGenerator/commit/6ac3ee74f4b68113e27fd3551c7c48e41cf16de0))
* add cqrs for getting processing statuses ([a503508](https://github.com/TomaszKandula/InvoiceGenerator/commit/a5035086f4c5027fbd73dca721a1d24475091472))
* add cqrs for removing invoice template, add validator ([254e620](https://github.com/TomaszKandula/InvoiceGenerator/commit/254e62056db9dbf5bc9fe143229bab23fa2a050a))
* add cqrs for replacing invoice template, add validator ([317d9b6](https://github.com/TomaszKandula/InvoiceGenerator/commit/317d9b6db7fbdf7e5a3164521714dedd6a560553))
* add CQRS service ([9e1e342](https://github.com/TomaszKandula/InvoiceGenerator/commit/9e1e342d3ef2e70d9001f755047b041549ed76e6))
* add database context and test base for UnitTest project ([0d4d630](https://github.com/TomaszKandula/InvoiceGenerator/commit/0d4d6305e52fd1d52224fd04cf9428e6e7c65c43))
* add database migration ([eaf8d12](https://github.com/TomaszKandula/InvoiceGenerator/commit/eaf8d12838ae7a840b86b783d982520b9742c2c4))
* add database migration for batch invoices ([65b1f19](https://github.com/TomaszKandula/InvoiceGenerator/commit/65b1f195b0fedb18df1c06f8779307fdecce82a5))
* add database packages and initial configuration ([c91d9d7](https://github.com/TomaszKandula/InvoiceGenerator/commit/c91d9d7193cc9a18adf60e664ad17fb77b55e310))
* add database table for batch invoices ([3e9803b](https://github.com/TomaszKandula/InvoiceGenerator/commit/3e9803b7dab149dbbfe162b2f3e3b89f389af13a))
* add database table for batch processing ([6f1d1c0](https://github.com/TomaszKandula/InvoiceGenerator/commit/6f1d1c0213117a58d6e356bbac1f8ec116f00e01))
* add database table for generated invoices ([dec5f6c](https://github.com/TomaszKandula/InvoiceGenerator/commit/dec5f6c8a2853bb650dd2344d93ced3c97da294b))
* add database table, add migration ([48e931e](https://github.com/TomaszKandula/InvoiceGenerator/commit/48e931e1c443404dfa82fc5852e3be0c839c1e58))
* add database tables ([8a4afc6](https://github.com/TomaszKandula/InvoiceGenerator/commit/8a4afc6eacab9b903a429828ebc0cac10a91cc05))
* add docker with github actions ([5cc5a62](https://github.com/TomaszKandula/InvoiceGenerator/commit/5cc5a62155ad4ffa4fe400a9324d44e43e6a4ffd))
* add domain enum for invoice processing status ([c1029ee](https://github.com/TomaszKandula/InvoiceGenerator/commit/c1029ee3b1147f2a54fe5de5f28274c36d4ad6a0))
* add domain enums ([b585b6d](https://github.com/TomaszKandula/InvoiceGenerator/commit/b585b6d1793141fd4235df65b080ef072227040b))
* add empty invoice service ([235fba1](https://github.com/TomaszKandula/InvoiceGenerator/commit/235fba109d4694b463fa6e83c4519b796ddbe214))
* add endpoint for getting batch processing status ([c933196](https://github.com/TomaszKandula/InvoiceGenerator/commit/c93319672c82dddfd3e7dce1596a0b58925b8f32))
* add enumerable extension for LINQ where clause ([1bdc879](https://github.com/TomaszKandula/InvoiceGenerator/commit/1bdc879d7a2775d403613cca34fb8a2b32eee2a3))
* add error code ([9d61aeb](https://github.com/TomaszKandula/InvoiceGenerator/commit/9d61aeb2870f84f9643e0fc5bffab269074baeab))
* add error code ([c30e5c6](https://github.com/TomaszKandula/InvoiceGenerator/commit/c30e5c6bcb195f0b2c9170872891f000499ed712))
* add error codes ([4f3bf77](https://github.com/TomaszKandula/InvoiceGenerator/commit/4f3bf77f4d5c40ab5349ef07aad3066427658e69))
* add error codes ([87a652e](https://github.com/TomaszKandula/InvoiceGenerator/commit/87a652e9a225e8dc20d3874654d6f3a190657d8e))
* add file size validation attribute ([066081f](https://github.com/TomaszKandula/InvoiceGenerator/commit/066081fcc6922b75838135c692133b865539a75e))
* add file size validation, remove unused rule ([9257c05](https://github.com/TomaszKandula/InvoiceGenerator/commit/9257c055dfdc7209e0e1c4178fc793877c6510ae))
* add initial database migration ([8b9b34e](https://github.com/TomaszKandula/InvoiceGenerator/commit/8b9b34e0645dc4766dd4875ce125886e5b77e767))
* add invoice controller ([154459d](https://github.com/TomaszKandula/InvoiceGenerator/commit/154459d1fc88cc8ae92447aa066dc8d464dc59c4))
* add invoice mapper ([66d44bd](https://github.com/TomaszKandula/InvoiceGenerator/commit/66d44bd80877583984ec97a860c2033210e72920))
* add invoice template name check ([deffd08](https://github.com/TomaszKandula/InvoiceGenerator/commit/deffd08e73ca2224a8932068b01300fe84e53936))
* add invoice templates database table ([0a440ae](https://github.com/TomaszKandula/InvoiceGenerator/commit/0a440ae1c36e2d571a649f67a57f458036934577))
* add mapping to database table ([e8ad1d6](https://github.com/TomaszKandula/InvoiceGenerator/commit/e8ad1d6cb6fc4df53c969e3bdaf018cbd9848755))
* add mappings to new database tables ([341bcd6](https://github.com/TomaszKandula/InvoiceGenerator/commit/341bcd66410032cc4e3ed82e02d154d8ec4e8e0d))
* add middleware ([675c1d8](https://github.com/TomaszKandula/InvoiceGenerator/commit/675c1d83494fd74ffa8f35d68a25c10e40c9c5eb))
* add models for invoice service ([0a9f03e](https://github.com/TomaszKandula/InvoiceGenerator/commit/0a9f03e152b8eea0e2ed929dbe2434f73d6af3b7))
* add navigation property to an entity ([4fa0015](https://github.com/TomaszKandula/InvoiceGenerator/commit/4fa00157b82bf37e51acd8158f8d98683c722cac))
* add new database table migration ([390c25b](https://github.com/TomaszKandula/InvoiceGenerator/commit/390c25bb9a6d33899bcd5675813fb87e9479535a))
* add new error code ([2a4ffbb](https://github.com/TomaszKandula/InvoiceGenerator/commit/2a4ffbbc7586ed611d63e3cde6238e6dfd910426))
* add new error codes ([a1bdf37](https://github.com/TomaszKandula/InvoiceGenerator/commit/a1bdf3799803442accb1be6150e293350110253a))
* add new error codes ([9f95ae8](https://github.com/TomaszKandula/InvoiceGenerator/commit/9f95ae8aad258a5760812370bf7947747dc04902))
* add new exceptions ([10bcdd8](https://github.com/TomaszKandula/InvoiceGenerator/commit/10bcdd848f188cb8874c9d87d3ccda9c245664b5))
* add new GET endpoint ([3098089](https://github.com/TomaszKandula/InvoiceGenerator/commit/309808966970fae4cbfb2b2d107c581f18c69ecf))
* add new GET endpoints ([18292cf](https://github.com/TomaszKandula/InvoiceGenerator/commit/18292cfe5bf79430c1e88fa4b4a214823c593131))
* add new implementation for getting issued invoice ([2062c28](https://github.com/TomaszKandula/InvoiceGenerator/commit/2062c28ef55294ef8c0fa181b1aa63a867906508))
* add new invoice data model ([ff60238](https://github.com/TomaszKandula/InvoiceGenerator/commit/ff602381340683e6fa7f3c163bd989327c3e28b2))
* add new mapper for invoice templates ([76f5644](https://github.com/TomaszKandula/InvoiceGenerator/commit/76f56443d8bfcb76ed1fe392d53a30f990756926))
* add new migration ([e48c490](https://github.com/TomaszKandula/InvoiceGenerator/commit/e48c490f242b752d9dfc50d08a68ddb69d111a2a))
* add new model ([ed59a5b](https://github.com/TomaszKandula/InvoiceGenerator/commit/ed59a5bf2bcf4cf596c800e6aadf5de23d220633))
* add new model for binary data ([4b7b635](https://github.com/TomaszKandula/InvoiceGenerator/commit/4b7b635faa428af4aaa45ea2c5bf09ea8fbda42a))
* add new model for invoice service ([b827efd](https://github.com/TomaszKandula/InvoiceGenerator/commit/b827efd7d595d5174ec23d3d63681e6a20503c68))
* add new model for invoice service ([e300119](https://github.com/TomaszKandula/InvoiceGenerator/commit/e3001192c513d0610c610726129d0d278dd5abe0))
* add new models ([6474960](https://github.com/TomaszKandula/InvoiceGenerator/commit/6474960a0e948389d136614b829c6f923d84f5fe))
* add new models ([039c85a](https://github.com/TomaszKandula/InvoiceGenerator/commit/039c85aa476099119055c6942f8e7eff8a86c569))
* add new unit tests for services ([b085565](https://github.com/TomaszKandula/InvoiceGenerator/commit/b085565f1f93db595dcb91fb707b0fc4e08b5ef8))
* add package reference ([bb982b7](https://github.com/TomaszKandula/InvoiceGenerator/commit/bb982b783e7041bd181df260b8882e8914c5b35d))
* add payment types to domain ([ae46746](https://github.com/TomaszKandula/InvoiceGenerator/commit/ae4674619261e30c8b87f0911a5d4bd5f150d0d6))
* add projects ([3c0168e](https://github.com/TomaszKandula/InvoiceGenerator/commit/3c0168ed7f8b3d4797bbf2419bf48b2f31b6b804))
* add semantic release ([5270fb7](https://github.com/TomaszKandula/InvoiceGenerator/commit/5270fb719fc92e1b7307d9041dac289307328a6b))
* add SHARED service ([20b157c](https://github.com/TomaszKandula/InvoiceGenerator/commit/20b157c098b8e611caca34635ecbd0e781bb7715))
* add table mapping ([fe4440b](https://github.com/TomaszKandula/InvoiceGenerator/commit/fe4440b3f5f9ab398978ae7149a4b962d371cc66))
* add test script to run docker (shorthand) ([3988285](https://github.com/TomaszKandula/InvoiceGenerator/commit/3988285f6e902801012fb48a8ec9738202e3fd4d))
* add tests for invoice service ([c25f0fd](https://github.com/TomaszKandula/InvoiceGenerator/commit/c25f0fddecc5b008ea9230d7e09c7eeafa7d8397))
* add two new implementations for invoice service ([4ef37d4](https://github.com/TomaszKandula/InvoiceGenerator/commit/4ef37d46a766115eadde9952eed8495433abb1f9))
* add user bank data table ([d031571](https://github.com/TomaszKandula/InvoiceGenerator/commit/d031571a587431e0c313148199bcf8bfd475a02f))
* add user secrets ([924594d](https://github.com/TomaszKandula/InvoiceGenerator/commit/924594deb515b2615305b8fa5b1625ab463d1110))
* add UserService to solution ([479803b](https://github.com/TomaszKandula/InvoiceGenerator/commit/479803b0ed76a3399210633a34d43fc7578e36b2))
* add VAT service ([c85bc38](https://github.com/TomaszKandula/InvoiceGenerator/commit/c85bc383feaccfc6161b4697ff0e0caf2a688b0c))
* change columns in database table, add migration ([62bb545](https://github.com/TomaszKandula/InvoiceGenerator/commit/62bb545c507ab76b82a57f8cbec599742ac27313))
* change file limit, add migrations ([d7a4a3f](https://github.com/TomaszKandula/InvoiceGenerator/commit/d7a4a3fe9e30b65403f436907ae819901fa13892))
* change max value of strings ([54c5a6b](https://github.com/TomaszKandula/InvoiceGenerator/commit/54c5a6bf058e6b31b0c927af1936c5f59b6780b7))
* configure api versioning with custom error respoonse ([796ee97](https://github.com/TomaszKandula/InvoiceGenerator/commit/796ee977742bebc1dcb6eb51f86c554ecd226173))
* extend invoice service implementation ([9e40512](https://github.com/TomaszKandula/InvoiceGenerator/commit/9e40512ada3a2122fdf183a91888f710b9405021))
* remove azure workflows, add custom scripts ([da8c76f](https://github.com/TomaszKandula/InvoiceGenerator/commit/da8c76fa7ba8a23cc50f4e32ac96b9667fb99ffd))
* rename and add to database context ([03947d7](https://github.com/TomaszKandula/InvoiceGenerator/commit/03947d76db04c8ea3db085b662353850e87cb947))
* split controllers, add new one ([7ca8ad9](https://github.com/TomaszKandula/InvoiceGenerator/commit/7ca8ad914d063c855621a97f217dbbff5ebdce83))
* update controllers for api versioning and response types ([10ecfd9](https://github.com/TomaszKandula/InvoiceGenerator/commit/10ecfd9a069f896d37c8ce7fdb49a8e44aa97884))
