using System.Linq.Expressions;
using BlazorApp1.Models;
using BlazorApp1.Repositories;

namespace BlazorApp1.Services;

public class CallService
{
    private readonly IBaseRepository<Call> _callRepository;

    public CallService(IBaseRepository<Call> callRepository)
    {
        _callRepository = callRepository;
    }

    public async Task AddCallAsync(Call call)
    {
        if (call == null)
        {
            throw new ArgumentNullException(nameof(call), "Call cannot be null.");
        }

        await _callRepository.AddAsync(call);
    }

    public async Task AddCallsAsync(IEnumerable<Call> calls)
    {
        if (calls == null || !calls.Any())
        {
            throw new ArgumentException("Calls collection cannot be null or empty.", nameof(calls));
        }

        await _callRepository.AddRangeAsync(calls);
    }

    public async Task<Call?> GetCallByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }

        return await _callRepository.GetIdAsync(id);
    }

    public async Task<Call?> GetCallAsync(Expression<Func<Call, bool>> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");
        }

        return await _callRepository.GetAsync(predicate);
    }

    public async Task<IEnumerable<Call>> GetCallsAsync(Expression<Func<Call, bool>> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");
        }

        return await _callRepository.GetListAsync(predicate);
    }

    public async Task<IEnumerable<Call>> GetAllCallsAsync()
    {
        return await _callRepository.GetAllAsync();
    }

    public async Task<int> CountCallsAsync()
    {
        return await _callRepository.CountAsync();
    }

    public async Task UpdateCallAsync(Call call)
    {
        if (call == null)
        {
            throw new ArgumentNullException(nameof(call), "Call cannot be null.");
        }

        await _callRepository.UpdateAsync(call);
    }

    public async Task RemoveCallAsync(Call call)
    {
        if (call == null)
        {
            throw new ArgumentNullException(nameof(call), "Call cannot be null.");
        }

        await _callRepository.RemoveAsync(call);
    }

    public async Task DisposeAsync()
    {
        await _callRepository.DisposeAsync();
    }
}
