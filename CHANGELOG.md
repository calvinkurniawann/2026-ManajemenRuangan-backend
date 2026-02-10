# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Semantic Versioning](https://semver.org/).

---

## [1.0.0] - 2026-02-XX
### Added
- Initial backend release
- Room master CRUD
- Room booking CRUD
- Room–booking relationship
- Booking status management (Pending, Approved, Rejected)
- Search and filter for booking history
- Soft delete for room booking
- Database migration and initial data seeding
- Swagger/OpenAPI documentation

### Changed
- Refactored controllers to use DTO for request and response
- Improved database structure for better data integrity

### Fixed
- Prevented deletion of rooms that are still used in bookings
- Improved validation for room booking update

---