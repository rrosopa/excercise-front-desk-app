using Application.Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace frontedesk.Controllers
{
    [Route("api/aa-seed-data")]
    public class AASeedDataController : ControllerBase
    {
        private readonly IAppDbContext _context;
        public AASeedDataController(IAppDbContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> SeedAsync()
        {
            if(_context.BoxTypes.Count() == 0)
            {
                _context.BoxTypes.AddRange(new[]{
                    new BoxType
                    {
                        Id = new Guid(Domain.Common.Constants.BoxTypes.Small),
                        Name = nameof(Domain.Common.Constants.BoxTypes.Small)
                    },
                    new BoxType
                    {
                        Id = new Guid(Domain.Common.Constants.BoxTypes.Medium),
                        Name = nameof(Domain.Common.Constants.BoxTypes.Medium)
                    },
                    new BoxType
                    {
                        Id = new Guid(Domain.Common.Constants.BoxTypes.Large),
                        Name = nameof(Domain.Common.Constants.BoxTypes.Large)
                    }
                });
            }

            if(_context.StorageAreaTypes.Count() == 0)
            {
                _context.StorageAreaTypes.AddRange(new[]
                {
                    new StorageAreaType
                    {
                        Id = new Guid(Domain.Common.Constants.StorageAreaTypes.Small),
                        Name = nameof(Domain.Common.Constants.StorageAreaTypes.Small)
                    },
                    new StorageAreaType
                    {
                        Id = new Guid(Domain.Common.Constants.StorageAreaTypes.Medium),
                        Name = nameof(Domain.Common.Constants.StorageAreaTypes.Medium)
                    },
                    new StorageAreaType
                    {
                        Id = new Guid(Domain.Common.Constants.StorageAreaTypes.Large),
                        Name = nameof(Domain.Common.Constants.StorageAreaTypes.Large)
                    }
                });
            }

            if (_context.StorageFacilities.Count() == 0)
            {
                _context.StorageFacilities.AddRange(new[]
                {
                    new StorageFacility
                    {
                        Name = "Facility A",
                        StorageAreas = new[]
                        {
                            new StorageArea
                            {
                                StorageAreaTypeId = new Guid(Domain.Common.Constants.StorageAreaTypes.Small),
                                TotalSpace = 5,
                                Name = "Small"
                            },
                            new StorageArea
                            {
                                StorageAreaTypeId = new Guid(Domain.Common.Constants.StorageAreaTypes.Medium),
                                TotalSpace = 5,
                                Name = "Medium"
                            },
                            new StorageArea
                            {
                                StorageAreaTypeId = new Guid(Domain.Common.Constants.StorageAreaTypes.Large),
                                TotalSpace = 5,
                                Name = "Large"
                            },
                        }
                    },
                    new StorageFacility
                    {
                        Name = "Facility B",
                        StorageAreas = new[]
                        {
                            new StorageArea
                            {
                                StorageAreaTypeId = new Guid(Domain.Common.Constants.StorageAreaTypes.Small),
                                TotalSpace = 10,
                                Name = "Small"
                            },
                            new StorageArea
                            {
                                StorageAreaTypeId = new Guid(Domain.Common.Constants.StorageAreaTypes.Medium),
                                TotalSpace = 15,
                                Name = "Medium"
                            },
                            new StorageArea
                            {
                                StorageAreaTypeId = new Guid(Domain.Common.Constants.StorageAreaTypes.Large),
                                TotalSpace = 25,
                                Name = "Large"
                            }
                        }
                    }
                });
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}