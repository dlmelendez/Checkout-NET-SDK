﻿
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Products
{
    /// <summary>
    /// The Product.
    /// </summary>
    [DataContract]
    public class ProductRequest 
    {
        /// <summary>
        /// The ID of the order.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The plan name.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The detailed description of the plan.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// The product type. Indicates whether the product is physical or digital goods, or a service.
        /// The possible values are:
        /// PHYSICAL.Physical goods
        /// DIGITAL.Digital goods
        /// SERVICE.Product representing a service.Example: Tech Support
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// The product category.
        /// The possible values are:
        /// AC_REFRIGERATION_REPAIR.A/C, Refrigeration Repair
        /// ACADEMIC_SOFTWARE.Academic Software
        /// ACCESSORIES.Accessories
        /// ACCOUNTING.Accounting
        /// ADULT.Adult
        /// ADVERTISING. Advertising
        /// AFFILIATED_AUTO_RENTAL. Affiliated Auto Rental
        /// AGENCIES. Agencies
        /// AGGREGATORS. Aggregators
        /// AGRICULTURAL_COOPERATIVE_FOR_MAIL_ORDER. Agricultural Cooperative for Mail Order
        /// AIR_CARRIERS_AIRLINES.Air Carriers, Airlines
        /// AIRLINES. Airlines
        /// AIRPORTS_FLYING_FIELDS. Airports, Flying Fields
        /// ALCOHOLIC_BEVERAGES.Alcoholic Beverages
        /// AMUSEMENT_PARKS_CARNIVALS.Amusement Parks/Carnivals
        /// ANIMATION. Animation
        /// ANTIQUES. Antiques
        /// APPLIANCES. Appliances
        /// AQUARIAMS_SEAQUARIUMS_DOLPHINARIUMS. Aquariams Seaquariums Dolphinariums
        /// ARCHITECTURAL_ENGINEERING_AND_SURVEYING_SERVICES. Architectural, Engineering, And Surveying Services
        /// ART_AND_CRAFT_SUPPLIES. Art & Craft Supplies
        /// ART_DEALERS_AND_GALLERIES.Art dealers and galleries
        /// ARTIFACTS_GRAVE_RELATED_AND_NATIVE_AMERICAN_CRAFTS.Artifacts, Grave related, and Native American Crafts
        /// ARTS_AND_CRAFTS.Arts and crafts
        /// ARTS_CRAFTS_AND_COLLECTIBLES. Arts, crafts, and collectibles
        /// AUDIO_BOOKS.Audio books
        /// AUTO_ASSOCIATIONS_CLUBS.Auto Associations/Clubs
        /// AUTO_DEALER_USED_ONLY. Auto dealer - used only
        /// AUTO_RENTALS.Auto Rentals
        /// AUTO_SERVICE.Auto service
        /// AUTOMATED_FUEL_DISPENSERS.Automated Fuel Dispensers
        /// AUTOMOBILE_ASSOCIATIONS. Automobile Associations
        /// AUTOMOTIVE.Automotive
        /// AUTOMOTIVE_REPAIR_SHOPS_NON_DEALER. Automotive Repair Shops - Non-Dealer
        /// AUTOMOTIVE_TOP_AND_BODY_SHOPS. Automotive Top And Body Shops
        /// AVIATION. Aviation
        /// BABIES_CLOTHING_AND_SUPPLIES. Babies Clothing & Supplies
        /// BABY. Baby
        /// BANDS_ORCHESTRAS_ENTERTAINERS. Bands, Orchestras, Entertainers
        /// BARBIES. Barbies
        /// BATH_AND_BODY. Bath and body
        /// BATTERIES. Batteries
        /// BEAN_BABIES. Bean Babies
        /// BEAUTY.Beauty
        /// BEAUTY_AND_FRAGRANCES. Beauty and fragrances
        /// BED_AND_BATH. Bed & Bath
        /// BICYCLE_SHOPS_SALES_AND_SERVICE. Bicycle Shops-Sales And Service
        /// BICYCLES_AND_ACCESSORIES. Bicycles & Accessories
        /// BILLIARD_POOL_ESTABLISHMENTS. Billiard/Pool Establishments
        /// BOAT_DEALERS.Boat Dealers
        /// BOAT_RENTALS_AND_LEASING.Boat Rentals And Leasing
        /// BOATING_SAILING_AND_ACCESSORIES.Boating, sailing and accessories
        /// BOOKS. Books
        /// BOOKS_AND_MAGAZINES. Books and magazines
        /// BOOKS_MANUSCRIPTS. Books, Manuscripts
        /// BOOKS_PERIODICALS_AND_NEWSPAPERS. Books, Periodicals And Newspapers
        /// BOWLING_ALLEYS. Bowling Alleys
        /// BULLETIN_BOARD.Bulletin board
        /// BUS_LINE.Bus line
        /// BUS_LINES_CHARTERS_TOUR_BUSES.Bus Lines, Charters, Tour Buses
        /// BUSINESS.Business
        /// BUSINESS_AND_SECRETARIAL_SCHOOLS. Business and secretarial schools
        /// BUYING_AND_SHOPPING_SERVICES_AND_CLUBS.Buying And Shopping Services And Clubs
        /// CABLE_SATELLITE_AND_OTHER_PAY_TELEVISION_AND_RADIO_SERVICES.Cable, Satellite, And Other Pay Television And Radio Services
        /// CABLE_SATELLITE_AND_OTHER_PAY_TV_AND_RADIO. Cable, satellite, and other pay TV and radio
        /// CAMERA_AND_PHOTOGRAPHIC_SUPPLIES.Camera and photographic supplies
        /// CAMERAS.Cameras
        /// CAMERAS_AND_PHOTOGRAPHY. Cameras & Photography
        /// CAMPER_RECREATIONAL_AND_UTILITY_TRAILER_DEALERS. Camper, Recreational And Utility Trailer Dealers
        /// CAMPING_AND_OUTDOORS. Camping and outdoors
        /// CAMPING_AND_SURVIVAL. Camping & Survival
        /// CAR_AND_TRUCK_DEALERS. Car And Truck Dealers
        /// CAR_AND_TRUCK_DEALERS_USED_ONLY.Car And Truck Dealers - Used Only
        /// CAR_AUDIO_AND_ELECTRONICS.Car Audio & Electronics
        /// CAR_RENTAL_AGENCY. Car rental agency
        /// CATALOG_MERCHANT. Catalog Merchant
        /// CATALOG_RETAIL_MERCHANT.Catalog/Retail Merchant
        /// CATERING_SERVICES.Catering services
        /// CHARITY.Charity
        /// CHECK_CASHIER. Check Cashier
        /// CHILD_CARE_SERVICES.Child Care Services
        /// CHILDREN_BOOKS. Children Books
        /// CHIROPODISTS_PODIATRISTS.Chiropodists/Podiatrists
        /// CHIROPRACTORS. Chiropractors
        /// CIGAR_STORES_AND_STANDS. Cigar Stores And Stands
        /// CIVIC_SOCIAL_FRATERNAL_ASSOCIATIONS.Civic, Social, Fraternal Associations
        /// CIVIL_SOCIAL_FRAT_ASSOCIATIONS.Civil/Social/Frat Associations
        /// CLOTHING.Clothing
        /// CLOTHING_ACCESSORIES_AND_SHOES. Clothing, accessories, and shoes
        /// CLOTHING_RENTAL.Clothing Rental
        /// COFFEE_AND_TEA.Coffee and tea
        /// COIN_OPERATED_BANKS_AND_CASINOS. Coin Operated Banks & Casinos
        /// COLLECTIBLES. Collectibles
        /// COLLECTION_AGENCY. Collection agency
        /// COLLEGES_AND_UNIVERSITIES.Colleges and universities
        /// COMMERCIAL_EQUIPMENT. Commercial Equipment
        /// COMMERCIAL_FOOTWEAR.Commercial Footwear
        /// COMMERCIAL_PHOTOGRAPHY.Commercial photography
        /// COMMERCIAL_PHOTOGRAPHY_ART_AND_GRAPHICS.Commercial photography, art, and graphics
        /// COMMERCIAL_SPORTS_PROFESSIONA.Commercial Sports/Professiona
        /// COMMODITIES_AND_FUTURES_EXCHANGE. Commodities and futures exchange
        /// COMPUTER_AND_DATA_PROCESSING_SERVICES.Computer and data processing services
        /// COMPUTER_HARDWARE_AND_SOFTWARE. Computer Hardware & Software
        /// COMPUTER_MAINTENANCE_REPAIR_AND_SERVICES_NOT_ELSEWHERE_CLAS. Computer Maintenance, Repair And Services Not Elsewhere Clas
        /// CONSTRUCTION.Construction
        /// CONSTRUCTION_MATERIALS_NOT_ELSEWHERE_CLASSIFIED. Construction Materials Not Elsewhere Classified
        /// CONSULTING_SERVICES. Consulting services
        /// CONSUMER_CREDIT_REPORTING_AGENCIES.Consumer Credit Reporting Agencies
        /// CONVALESCENT_HOMES.Convalescent Homes
        /// COSMETIC_STORES.Cosmetic Stores
        /// COUNSELING_SERVICES_DEBT_MARRIAGE_PERSONAL.Counseling Services--Debt, Marriage, Personal
        /// COUNTERFEIT_CURRENCY_AND_STAMPS. Counterfeit Currency and Stamps
        /// COUNTERFEIT_ITEMS.Counterfeit Items
        /// COUNTRY_CLUBS.Country Clubs
        /// COURIER_SERVICES.Courier services
        /// COURIER_SERVICES_AIR_AND_GROUND_AND_FREIGHT_FORWARDERS.Courier Services-Air And Ground, And Freight Forwarders
        /// COURT_COSTS_ALIMNY_CHILD_SUPT. Court Costs/Alimny/Child Supt
        /// COURT_COSTS_INCLUDING_ALIMONY_AND_CHILD_SUPPORT_COURTS_OF_LAW.Court Costs, Including Alimony and Child Support - Courts of Law
        /// CREDIT_CARDS. Credit Cards
        /// CREDIT_UNION.Credit union
        /// CULTURE_AND_RELIGION.Culture & Religion
        /// DAIRY_PRODUCTS_STORES. Dairy Products Stores
        /// DANCE_HALLS_STUDIOS_AND_SCHOOLS. Dance Halls, Studios, And Schools
        /// DECORATIVE.Decorative
        /// DENTAL. Dental
        /// DENTISTS_AND_ORTHODONTISTS. Dentists And Orthodontists
        /// DEPARTMENT_STORES. Department Stores
        /// DESKTOP_PCS.Desktop PCs
        /// DEVICES.Devices
        /// DIECAST_TOYS_VEHICLES. Diecast, Toys Vehicles
        /// DIGITAL_GAMES.Digital games
        /// DIGITAL_MEDIA_BOOKS_MOVIES_MUSIC.Digital media, books, movies, music
        /// DIRECT_MARKETING. Direct Marketing
        /// DIRECT_MARKETING_CATALOG_MERCHANT.Direct Marketing - Catalog Merchant
        /// DIRECT_MARKETING_INBOUND_TELE.Direct Marketing - Inbound Tele
        /// DIRECT_MARKETING_OUTBOUND_TELE.Direct Marketing - Outbound Tele
        /// DIRECT_MARKETING_SUBSCRIPTION.Direct Marketing - Subscription
        /// DISCOUNT_STORES. Discount Stores
        /// DOOR_TO_DOOR_SALES.Door-To-Door Sales
        /// DRAPERY_WINDOW_COVERING_AND_UPHOLSTERY.Drapery, window covering, and upholstery
        /// DRINKING_PLACES.Drinking Places
        /// DRUGSTORE.Drugstore
        /// DURABLE_GOODS. Durable goods
        /// ECOMMERCE_DEVELOPMENT.eCommerce Development
        /// ECOMMERCE_SERVICES.eCommerce Services
        /// EDUCATIONAL_AND_TEXTBOOKS.Educational and textbooks
        /// ELECTRIC_RAZOR_STORES. Electric Razor Stores
        /// ELECTRICAL_AND_SMALL_APPLIANCE_REPAIR. Electrical and small appliance repair
        /// ELECTRICAL_CONTRACTORS. Electrical Contractors
        /// ELECTRICAL_PARTS_AND_EQUIPMENT.Electrical Parts and Equipment
        /// ELECTRONIC_CASH.Electronic Cash
        /// ELEMENTARY_AND_SECONDARY_SCHOOLS.Elementary and secondary schools
        /// EMPLOYMENT.Employment
        /// ENTERTAINERS. Entertainers
        /// ENTERTAINMENT_AND_MEDIA. Entertainment and media
        /// EQUIP_TOOL_FURNITURE_AND_APPLIANCE_RENTAL_AND_LEASING. Equip, Tool, Furniture, And Appliance Rental And Leasing
        /// ESCROW. Escrow
        /// EVENT_AND_WEDDING_PLANNING. Event & Wedding Planning
        /// EXERCISE_AND_FITNESS.Exercise and fitness
        /// EXERCISE_EQUIPMENT. Exercise Equipment
        /// EXTERMINATING_AND_DISINFECTING_SERVICES.Exterminating and disinfecting services
        /// FABRICS_AND_SEWING.Fabrics & Sewing
        /// FAMILY_CLOTHING_STORES. Family Clothing Stores
        /// FASHION_JEWELRY. Fashion jewelry
        /// FAST_FOOD_RESTAURANTS.Fast Food Restaurants
        /// FICTION_AND_NONFICTION. Fiction and nonfiction
        /// FINANCE_COMPANY. Finance company
        /// FINANCIAL_AND_INVESTMENT_ADVICE.Financial and investment advice
        /// FINANCIAL_INSTITUTIONS_MERCHANDISE_AND_SERVICES.Financial Institutions - Merchandise And Services
        /// FIREARM_ACCESSORIES. Firearm accessories
        /// FIREARMS_WEAPONS_AND_KNIVES.Firearms, Weapons and Knives
        /// FIREPLACE_AND_FIREPLACE_SCREENS. Fireplace, and fireplace screens
        /// FIREWORKS. Fireworks
        /// FISHING. Fishing
        /// FLORISTS. Florists
        /// FLOWERS. Flowers
        /// FOOD_DRINK_AND_NUTRITION. Food, Drink & Nutrition
        /// FOOD_PRODUCTS. Food Products
        /// FOOD_RETAIL_AND_SERVICE.Food retail and service
        /// FRAGRANCES_AND_PERFUMES.Fragrances and perfumes
        /// FREEZER_AND_LOCKER_MEAT_PROVISIONERS. Freezer and Locker Meat Provisioners
        /// FUEL_DEALERS_FUEL_OIL_WOOD_AND_COAL. Fuel Dealers-Fuel Oil, Wood & Coal
        /// FUEL_DEALERS_NON_AUTOMOTIVE. Fuel Dealers - Non Automotive
        /// FUNERAL_SERVICES_AND_CREMATORIES.Funeral Services & Crematories
        /// FURNISHING_AND_DECORATING. Furnishing & Decorating
        /// FURNITURE. Furniture
        /// FURRIERS_AND_FUR_SHOPS. Furriers and Fur Shops
        /// GADGETS_AND_OTHER_ELECTRONICS.Gadgets & other electronics
        /// GAMBLING.Gambling
        /// GAME_SOFTWARE. Game Software
        /// GAMES.Games
        /// GARDEN_SUPPLIES. Garden supplies
        /// GENERAL.General
        /// GENERAL_CONTRACTORS. General contractors
        /// GENERAL_GOVERNMENT.General - Government
        /// GENERAL_SOFTWARE. General - Software
        /// GENERAL_TELECOM. General - Telecom
        /// GIFTS_AND_FLOWERS. Gifts and flowers
        /// GLASS_PAINT_AND_WALLPAPER_STORES. Glass, Paint, And Wallpaper Stores
        /// GLASSWARE_CRYSTAL_STORES. Glassware, Crystal Stores
        /// GOVERNMENT.Government
        /// GOVERNMENT_IDS_AND_LICENSES. Government IDs and Licenses
        /// GOVERNMENT_LICENSED_ON_LINE_CASINOS_ON_LINE_GAMBLING.Government Licensed On-Line Casinos - On-Line Gambling
        /// GOVERNMENT_OWNED_LOTTERIES.Government-Owned Lotteries
        /// GOVERNMENT_SERVICES.Government services
        /// GRAPHIC_AND_COMMERCIAL_DESIGN.Graphic & Commercial Design
        /// GREETING_CARDS.Greeting Cards
        /// GROCERY_STORES_AND_SUPERMARKETS.Grocery Stores & Supermarkets
        /// HARDWARE_AND_TOOLS. Hardware & Tools
        /// HARDWARE_EQUIPMENT_AND_SUPPLIES. Hardware, Equipment, and Supplies
        /// HAZARDOUS_RESTRICTED_AND_PERISHABLE_ITEMS.Hazardous, Restricted and Perishable Items
        /// HEALTH_AND_BEAUTY_SPAS.Health and beauty spas
        /// HEALTH_AND_NUTRITION.Health & Nutrition
        /// HEALTH_AND_PERSONAL_CARE. Health and personal care
        /// HEARING_AIDS_SALES_AND_SUPPLIES.Hearing Aids Sales and Supplies
        /// HEATING_PLUMBING_AC. Heating, Plumbing, AC
        /// HIGH_RISK_MERCHANT. High Risk Merchant
        /// HIRING_SERVICES. Hiring services
        /// HOBBIES_TOYS_AND_GAMES.Hobbies, Toys & Games
        /// HOME_AND_GARDEN. Home and garden
        /// HOME_AUDIO. Home Audio
        /// HOME_DECOR.Home decor
        /// HOME_ELECTRONICS.Home Electronics
        /// HOSPITALS.Hospitals
        /// HOTELS_MOTELS_INNS_RESORTS. Hotels/Motels/Inns/Resorts
        /// HOUSEWARES. Housewares
        /// HUMAN_PARTS_AND_REMAINS. Human Parts and Remains
        /// HUMOROUS_GIFTS_AND_NOVELTIES.Humorous Gifts & Novelties
        /// HUNTING. Hunting
        /// IDS_LICENSES_AND_PASSPORTS. IDs, licenses, and passports
        /// ILLEGAL_DRUGS_AND_PARAPHERNALIA.Illegal Drugs & Paraphernalia
        /// INDUSTRIAL. Industrial
        /// INDUSTRIAL_AND_MANUFACTURING_SUPPLIES. Industrial and manufacturing supplies
        /// INSURANCE_AUTO_AND_HOME.Insurance - auto and home
        /// INSURANCE_DIRECT. Insurance - Direct
        /// INSURANCE_LIFE_AND_ANNUITY. Insurance - life and annuity
        /// INSURANCE_SALES_UNDERWRITING. Insurance Sales/Underwriting
        /// INSURANCE_UNDERWRITING_PREMIUMS. Insurance Underwriting, Premiums
        /// INTERNET_AND_NETWORK_SERVICES. Internet & Network Services
        /// INTRA_COMPANY_PURCHASES.Intra-Company Purchases
        /// LABORATORIES_DENTAL_MEDICAL.Laboratories-Dental/Medical
        /// LANDSCAPING. Landscaping
        /// LANDSCAPING_AND_HORTICULTURAL_SERVICES. Landscaping And Horticultural Services
        /// LAUNDRY_CLEANING_SERVICES.Laundry, Cleaning Services
        /// LEGAL.Legal
        /// LEGAL_SERVICES_AND_ATTORNEYS. Legal services and attorneys
        /// LOCAL_DELIVERY_SERVICE.Local delivery service
        /// LOCKSMITH. Locksmith
        /// LODGING_AND_ACCOMMODATIONS. Lodging and accommodations
        /// LOTTERY_AND_CONTESTS. Lottery and contests
        /// LUGGAGE_AND_LEATHER_GOODS. Luggage and leather goods
        /// LUMBER_AND_BUILDING_MATERIALS.Lumber & Building Materials
        /// MAGAZINES.Magazines
        /// MAINTENANCE_AND_REPAIR_SERVICES. Maintenance and repair services
        /// MAKEUP_AND_COSMETICS.Makeup and cosmetics
        /// MANUAL_CASH_DISBURSEMENTS. Manual Cash Disbursements
        /// MASSAGE_PARLORS. Massage Parlors
        /// MEDICAL.Medical
        /// MEDICAL_AND_PHARMACEUTICAL. Medical & Pharmaceutical
        /// MEDICAL_CARE. Medical care
        /// MEDICAL_EQUIPMENT_AND_SUPPLIES.Medical equipment and supplies
        /// MEDICAL_SERVICES.Medical Services
        /// MEETING_PLANNERS.Meeting Planners
        /// MEMBERSHIP_CLUBS_AND_ORGANIZATIONS.Membership clubs and organizations
        /// MEMBERSHIP_COUNTRY_CLUBS_GOLF.Membership/Country Clubs/Golf
        /// MEMORABILIA. Memorabilia
        /// MEN_AND_BOY_CLOTHING_AND_ACCESSORY_STORES. Men's And Boy's Clothing And Accessory Stores
        /// MEN_CLOTHING. Men's Clothing
        /// MERCHANDISE.Merchandise
        /// METAPHYSICAL. Metaphysical
        /// MILITARIA. Militaria
        /// MILITARY_AND_CIVIL_SERVICE_UNIFORMS. Military and civil service uniforms
        /// MISC._AUTOMOTIVE_AIRCRAFT_AND_FARM_EQUIPMENT_DEALERS.Misc.Automotive, Aircraft, And Farm Equipment Dealers
        /// MISC._GENERAL_MERCHANDISE.Misc.General Merchandise
        /// MISCELLANEOUS_GENERAL_SERVICES.Miscellaneous General Services
        /// MISCELLANEOUS_REPAIR_SHOPS_AND_RELATED_SERVICES. Miscellaneous Repair Shops And Related Services
        /// MODEL_KITS.Model Kits
        /// MONEY_TRANSFER_MEMBER_FINANCIAL_INSTITUTION.Money Transfer - Member Financial Institution
        /// MONEY_TRANSFER_MERCHANT. Money Transfer--Merchant
        /// MOTION_PICTURE_THEATERS. Motion Picture Theaters
        /// MOTOR_FREIGHT_CARRIERS_AND_TRUCKING. Motor Freight Carriers & Trucking
        /// MOTOR_HOME_AND_RECREATIONAL_VEHICLE_RENTAL. Motor Home And Recreational Vehicle Rental
        /// MOTOR_HOMES_DEALERS.Motor Homes Dealers
        /// MOTOR_VEHICLE_SUPPLIES_AND_NEW_PARTS. Motor Vehicle Supplies and New Parts
        /// MOTORCYCLE_DEALERS.Motorcycle Dealers
        /// MOTORCYCLES.Motorcycles
        /// MOVIE. Movie
        /// MOVIE_TICKETS. Movie tickets
        /// MOVING_AND_STORAGE.Moving and storage
        /// MULTI_LEVEL_MARKETING. Multi-level marketing
        /// MUSIC_CDS_CASSETTES_AND_ALBUMS.Music - CDs, cassettes and albums
        /// MUSIC_STORE_INSTRUMENTS_AND_SHEET_MUSIC. Music store - instruments and sheet music
        /// NETWORKING.Networking
        /// NEW_AGE. New Age
        /// NEW_PARTS_AND_SUPPLIES_MOTOR_VEHICLE.New parts and supplies - motor vehicle
        /// NEWS_DEALERS_AND_NEWSTANDS.News Dealers and Newstands
        /// NON_DURABLE_GOODS.Non-durable goods
        /// NON_FICTION.Non-Fiction
        /// NON_PROFIT_POLITICAL_AND_RELIGION. Non-Profit, Political & Religion
        /// NONPROFIT. Nonprofit
        /// NOVELTIES. Novelties
        /// OEM_SOFTWARE. Oem Software
        /// OFFICE_SUPPLIES_AND_EQUIPMENT.Office Supplies and Equipment
        /// ONLINE_DATING.Online Dating
        /// ONLINE_GAMING.Online gaming
        /// ONLINE_GAMING_CURRENCY.Online gaming currency
        /// ONLINE_SERVICES. online services
        /// OOUTBOUND_TELEMARKETING_MERCH.Ooutbound Telemarketing Merch
        /// OPHTHALMOLOGISTS_OPTOMETRIST. Ophthalmologists/Optometrist
        /// OPTICIANS_AND_DISPENSING. Opticians And Dispensing
        /// ORTHOPEDIC_GOODS_PROSTHETICS. Orthopedic Goods/Prosthetics
        /// OSTEOPATHS. Osteopaths
        /// OTHER. Other
        /// PACKAGE_TOUR_OPERATORS. Package Tour Operators
        /// PAINTBALL. Paintball
        /// PAINTS_VARNISHES_AND_SUPPLIES. Paints, Varnishes, and Supplies
        /// PARKING_LOTS_AND_GARAGES.Parking Lots & Garages
        /// PARTS_AND_ACCESSORIES. Parts and accessories
        /// PAWN_SHOPS. Pawn Shops
        /// PAYCHECK_LENDER_OR_CASH_ADVANCE.Paycheck lender or cash advance
        /// PERIPHERALS. Peripherals
        /// PERSONALIZED_GIFTS. Personalized Gifts
        /// PET_SHOPS_PET_FOOD_AND_SUPPLIES.Pet shops, pet food, and supplies
        /// PETROLEUM_AND_PETROLEUM_PRODUCTS.Petroleum and Petroleum Products
        /// PETS_AND_ANIMALS.Pets and animals
        /// PHOTOFINISHING_LABORATORIES_PHOTO_DEVELOPING. Photofinishing Laboratories, Photo Developing
        /// PHOTOGRAPHIC_STUDIOS_PORTRAITS.Photographic studios - portraits
        /// PHOTOGRAPHY. Photography
        /// PHYSICAL_GOOD. Physical Good
        /// PICTURE_VIDEO_PRODUCTION.Picture/Video Production
        /// PIECE_GOODS_NOTIONS_AND_OTHER_DRY_GOODS.Piece Goods Notions and Other Dry Goods
        /// PLANTS_AND_SEEDS. Plants and Seeds
        /// PLUMBING_AND_HEATING_EQUIPMENTS_AND_SUPPLIES. Plumbing & Heating Equipments & Supplies
        /// POLICE_RELATED_ITEMS. Police-Related Items
        /// POLITICAL_ORGANIZATIONS.Politcal Organizations
        /// POSTAL_SERVICES_GOVERNMENT_ONLY.Postal Services - Government Only
        /// POSTERS.Posters
        /// PREPAID_AND_STORED_VALUE_CARDS. Prepaid and stored value cards
        /// PRESCRIPTION_DRUGS. Prescription Drugs
        /// PROMOTIONAL_ITEMS.Promotional Items
        /// PUBLIC_WAREHOUSING_AND_STORAGE.Public Warehousing and Storage
        /// PUBLISHING_AND_PRINTING.Publishing and printing
        /// PUBLISHING_SERVICES. Publishing Services
        /// RADAR_DECTORS.Radar Dectors
        /// RADIO_TELEVISION_AND_STEREO_REPAIR.Radio, television, and stereo repair
        /// REAL_ESTATE. Real Estate
        /// REAL_ESTATE_AGENT.Real estate agent
        /// REAL_ESTATE_AGENTS_AND_MANAGERS_RENTALS. Real Estate Agents And Managers - Rentals
        /// RELIGION_AND_SPIRITUALITY_FOR_PROFIT. Religion and spirituality for profit
        /// RELIGIOUS. Religious
        /// RELIGIOUS_ORGANIZATIONS. Religious Organizations
        /// REMITTANCE.Remittance
        /// RENTAL_PROPERTY_MANAGEMENT. Rental property management
        /// RESIDENTIAL. Residential
        /// RETAIL. Retail
        /// RETAIL_FINE_JEWELRY_AND_WATCHES. Retail - fine jewelry and watches
        /// REUPHOLSTERY_AND_FURNITURE_REPAIR.Reupholstery and furniture repair
        /// RINGS.Rings
        /// ROOFING_SIDING_SHEET_METAL. Roofing/Siding, Sheet Metal
        /// RUGS_AND_CARPETS.Rugs & Carpets
        /// SCHOOLS_AND_COLLEGES. Schools and Colleges
        /// SCIENCE_FICTION. Science Fiction
        /// SCRAPBOOKING.Scrapbooking
        /// SCULPTURES. Sculptures
        /// SECURITIES_BROKERS_AND_DEALERS. Securities - Brokers And Dealers
        /// SECURITY_AND_SURVEILLANCE. Security and surveillance
        /// SECURITY_AND_SURVEILLANCE_EQUIPMENT. Security and surveillance equipment
        /// SECURITY_BROKERS_AND_DEALERS.Security brokers and dealers
        /// SEMINARS.Seminars
        /// SERVICE_STATIONS. Service Stations
        /// SERVICES.Services
        /// SEWING_NEEDLEWORK_FABRIC_AND_PIECE_GOODS_STORES. Sewing, Needlework, Fabric And Piece Goods Stores
        /// SHIPPING_AND_PACKING. Shipping & Packaging
        /// SHOE_REPAIR_HAT_CLEANING. Shoe Repair/Hat Cleaning
        /// SHOE_STORES.Shoe Stores
        /// SHOES.Shoes
        /// SNOWMOBILE_DEALERS. Snowmobile Dealers
        /// SOFTWARE.Software
        /// SPECIALTY_AND_MISC._FOOD_STORES.Specialty and misc.food stores
        /// SPECIALTY_CLEANING_POLISHING_AND_SANITATION_PREPARATIONS.Specialty Cleaning, Polishing And Sanitation Preparations
        /// SPECIALTY_OR_RARE_PETS.Specialty or rare pets
        /// SPORT_GAMES_AND_TOYS.Sport games and toys
        /// SPORTING_AND_RECREATIONAL_CAMPS.Sporting And Recreational Camps
        /// SPORTING_GOODS.Sporting Goods
        /// SPORTS_AND_OUTDOORS.Sports and outdoors
        /// SPORTS_AND_RECREATION. Sports & Recreation
        /// STAMP_AND_COIN. Stamp and coin
        /// STATIONARY_PRINTING_AND_WRITING_PAPER. Stationary, printing, and writing paper
        /// STENOGRAPHIC_AND_SECRETARIAL_SUPPORT_SERVICES. Stenographic and secretarial support services
        /// STOCKS_BONDS_SECURITIES_AND_RELATED_CERTIFICATES. Stocks, Bonds, Securities and Related Certificates
        /// STORED_VALUE_CARDS.Stored Value Cards
        /// SUPPLIES. Supplies
        /// SUPPLIES_AND_TOYS. Supplies & Toys
        /// SURVEILLANCE_EQUIPMENT. Surveillance Equipment
        /// SWIMMING_POOLS_AND_SPAS.Swimming Pools & Spas
        /// SWIMMING_POOLS_SALES_SUPPLIES_SERVICES. Swimming Pools-Sales, Supplies, Services
        /// TAILORS_AND_ALTERATIONS. Tailors and alterations
        /// TAX_PAYMENTS. Tax Payments
        /// TAX_PAYMENTS_GOVERNMENT_AGENCIES.Tax Payments - Government Agencies
        /// TAXICABS_AND_LIMOUSINES.Taxicabs and limousines
        /// TELECOMMUNICATION_SERVICES. Telecommunication Services
        /// TELEPHONE_CARDS.Telephone Cards
        /// TELEPHONE_EQUIPMENT.Telephone Equipment
        /// TELEPHONE_SERVICES.Telephone Services
        /// THEATER.Theater
        /// TIRE_RETREADING_AND_REPAIR. Tire Retreading and Repair
        /// TOLL_OR_BRIDGE_FEES.Toll or Bridge Fees
        /// TOOLS_AND_EQUIPMENT.Tools and equipment
        /// TOURIST_ATTRACTIONS_AND_EXHIBITS. Tourist Attractions And Exhibits
        /// TOWING_SERVICE.Towing service
        /// TOYS_AND_GAMES.Toys and games
        /// TRADE_AND_VOCATIONAL_SCHOOLS. Trade And Vocational Schools
        /// TRADEMARK_INFRINGEMENT.Trademark Infringement
        /// TRAILER_PARKS_AND_CAMPGROUNDS.Trailer Parks And Campgrounds
        /// TRAINING_SERVICES.Training services
        /// TRANSPORTATION_SERVICES.Transportation Services
        /// TRAVEL.Travel
        /// TRUCK_AND_UTILITY_TRAILER_RENTALS. Truck And Utility Trailer Rentals
        /// TRUCK_STOP. Truck Stop
        /// TYPESETTING_PLATE_MAKING_AND_RELATED_SERVICES.Typesetting, Plate Making, and Related Services
        /// USED_MERCHANDISE_AND_SECONDHAND_STORES. Used Merchandise And Secondhand Stores
        /// USED_PARTS_MOTOR_VEHICLE. Used parts - motor vehicle
        /// UTILITIES.Utilities
        /// UTILITIES_ELECTRIC_GAS_WATER_SANITARY. Utilities - Electric, Gas, Water, Sanitary
        /// VARIETY_STORES. Variety Stores
        /// VEHICLE_SALES.Vehicle sales
        /// VEHICLE_SERVICE_AND_ACCESSORIES.Vehicle service and accessories
        /// VIDEO_EQUIPMENT.Video Equipment
        /// VIDEO_GAME_ARCADES_ESTABLISH.Video Game Arcades/Establish
        /// VIDEO_GAMES_AND_SYSTEMS. Video Games & Systems
        /// VIDEO_TAPE_RENTAL_STORES. Video Tape Rental Stores
        /// VINTAGE_AND_COLLECTIBLE_VEHICLES.Vintage and Collectible Vehicles
        /// VINTAGE_AND_COLLECTIBLES.Vintage and collectibles
        /// VITAMINS_AND_SUPPLEMENTS. Vitamins & Supplements
        /// VOCATIONAL_AND_TRADE_SCHOOLS. Vocational and trade schools
        /// WATCH_CLOCK_AND_JEWELRY_REPAIR.Watch, clock, and jewelry repair
        /// WEB_HOSTING_AND_DESIGN. Web hosting and design
        /// WELDING_REPAIR.Welding Repair
        /// WHOLESALE_CLUBS.Wholesale Clubs
        /// WHOLESALE_FLORIST_SUPPLIERS.Wholesale Florist Suppliers
        /// WHOLESALE_PRESCRIPTION_DRUGS. Wholesale Prescription Drugs
        /// WILDLIFE_PRODUCTS. Wildlife Products
        /// WIRE_TRANSFER.Wire Transfer
        /// WIRE_TRANSFER_AND_MONEY_ORDER.Wire transfer and money order
        /// WOMEN_ACCESSORY_SPECIALITY. Women's Accessory/Speciality
        /// WOMEN_CLOTHING.Women's clothing
        /// </summary>
        [DataMember(Name = "category", EmitDefaultValue = false)]
        [JsonPropertyName("category")]
        public string? Category { get; set; }

        /// <summary>
        /// The image URL for the product.
        /// </summary>
        [DataMember(Name = "image_url", EmitDefaultValue = false)]
        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// The home page URL for the product.
        /// </summary>
        [DataMember(Name = "home_url", EmitDefaultValue = false)]
        [JsonPropertyName("home_url")]
        public string? HomeUrl { get; set; }

    }
}

