namespace CossSharp.Lib.Models
{
    public class CossAccountKyc
    {
        //	"first_name": "",
        public string FirstName { get; set; }

        //	"last_name": null,
        public string LastName { get; set; }

        //	"gender": "male",
        public string Gender { get; set; }

        //	"country_of_citizenship": "",
        public string CountryOfCitizenship { get; set; }

        //	"country_of_resident": "",
        public string CountryOfResident { get; set; }

        //	"passport_id_drivers_license_id_national_id": null,
        public string PassportIdDriversLicenseIdNationalId { get; set; }

        //	"passport_cover": null,
        public string PassportCover { get; set; }

        //	"passport_personal_page": "url",
        public string PassportPersonalPage { get; set; }

        //	"selfie_with_photo_id_and_note": url,
        public string SelfieWithPhotoIdAndNote { get; set; }

        //	"token": null,
        public string Token { get; set; }

        //	"kyc_reject_infos": null,

        //	"phone_country_code": null,
        public string PhoneCountryCode { get; set; }

        //	"phone_number": null,
        public string PhoneNumber { get; set; }

        //	"alias_name": "",
        public string AliasName { get; set; }

        //	"date_of_birth": numeric,
        public long DateOfBirth { get; set; }

        //	"address": "",
        public string Address { get; set; }

        //	"residentialAddress": {
        //		"city": null,
        //		"state": null,
        //		"postal_code": null,
        //		"address_line_1": null,
        //		"address_line_2": null,
        //		"government_issued_photo_id_expiry_date": 0
        //	},

        //	"proof_of_residency": null,

        //	"other_documents": null
    }
}
